using System.Windows.Forms.VisualStyles;
using SDA_559ir.Data;
using SDA_559ir.Models;

namespace SDA_559ir.Views
{
    public partial class OrdersView : UserControl
    {
        public event EventHandler? BackRequested;
        public event EventHandler<long>? EditRequested;

        private readonly OrderRepository _orderRepo = new OrderRepository();
        private readonly CourierRepository _courierRepo = new CourierRepository();
        private readonly OrderProcessingQueue _processingQueue = new OrderProcessingQueue();

        private readonly System.Windows.Forms.Timer _searchTimer = new System.Windows.Forms.Timer();
        private readonly Label _lblQueueSummary = new Label();
        private readonly Button _btnProcessNext = new Button();

        public OrdersView()
        {
            InitializeComponent();
            InitializeQueueControls();
            InitializeGrid();

            btnBack.Click += (_, __) => BackRequested?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (_, __) =>
            {
                txtSearch.Text = "";
                cmbCourier.SelectedIndex = 0;
                RefreshGrid();
            };

            txtSearch.TextChanged += (_, __) =>
            {
                // Debounce search
                _searchTimer.Stop();
                _searchTimer.Start();
            };

            cmbCourier.SelectedIndexChanged += (_, __) => RefreshGrid();

            _searchTimer.Interval = 300;
            _searchTimer.Tick += (_, __) =>
            {
                _searchTimer.Stop();
                RefreshGrid();
            };

            LoadCouriers();
            RefreshGrid();

            gridOrders.CellPainting += gridOrders_CellPainting;
            gridOrders.CellMouseClick += gridOrders_CellMouseClick;
        }

        private void LoadCouriers()
        {
            var list = _courierRepo.GetAll(null, true);

            var ds = new List<Courier>();
            ds.Add(new Courier { Id = 0, Name = "All" });
            ds.AddRange(list);

            cmbCourier.DisplayMember = "Name";
            cmbCourier.ValueMember = "Id";
            cmbCourier.DataSource = ds;
            cmbCourier.SelectedIndex = 0;
        }

        private void InitializeQueueControls()
        {
            topPanel.Height = 128;

            _lblQueueSummary.AutoSize = false;
            _lblQueueSummary.Location = new Point(120, 88);
            _lblQueueSummary.Size = new Size(520, 28);
            _lblQueueSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            _lblQueueSummary.Text = "Queue: loading...";

            _btnProcessNext.Location = new Point(650, 87);
            _btnProcessNext.Size = new Size(180, 30);
            _btnProcessNext.Text = "Process next order";
            _btnProcessNext.UseVisualStyleBackColor = true;
            _btnProcessNext.Click += (_, __) => ProcessNextOrder();

            topPanel.Controls.Add(_lblQueueSummary);
            topPanel.Controls.Add(_btnProcessNext);
        }

        private void InitializeGrid()
        {
            gridOrders.AllowUserToAddRows = false;
            gridOrders.AllowUserToDeleteRows = false;
            gridOrders.ReadOnly = true;
            gridOrders.MultiSelect = false;
            gridOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridOrders.RowHeadersVisible = false;

            gridOrders.Columns.Clear();

            gridOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "order_id",
                HeaderText = "ID",
                FillWeight = 10
            });

            gridOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "customer_name",
                HeaderText = "Име",
                FillWeight = 20
            });

            gridOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "customer_phone",
                HeaderText = "Телефон",
                FillWeight = 15
            });

            gridOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "delivery_address",
                HeaderText = "Адрес",
                FillWeight = 40
            });

            gridOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "total_eur",
                HeaderText = "Сума (EUR)",
                FillWeight = 10
            });

            gridOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "actions",
                HeaderText = "Действия",
                FillWeight = 10
            });
        }

        public void RefreshGrid()
        {
            gridOrders.Rows.Clear();

            var q = (txtSearch.Text ?? "").Trim();
            var courierId = GetSelectedCourierIdOrNull();

            var rows = _orderRepo.SearchOrders(q, courierId);

            foreach (var r in rows)
            {
                gridOrders.Rows.Add(
                    r.OrderId,
                    r.CustomerName,
                    r.CustomerPhone,
                    r.DeliveryAddress,
                    r.TotalEur.ToString("0.00"),
                    "" // actions column is painted manually
                );
            }

            RefreshQueueSummary();
        }

        private void RefreshQueueSummary()
        {
            var newOrders = _orderRepo.GetOrdersByStatus(OrderStatus.New);
            _processingQueue.Rebuild(newOrders);

            var next = _processingQueue.PeekOrDefault();
            if (next == null)
            {
                _lblQueueSummary.Text = "Queue: no waiting orders.";
                _btnProcessNext.Enabled = false;
                return;
            }

            _lblQueueSummary.Text =
                $"Queue: {_processingQueue.Count} waiting | Next: #{next.OrderId} - {next.CustomerName}";
            _btnProcessNext.Enabled = true;
        }

        private void ProcessNextOrder()
        {
            var next = _processingQueue.DequeueOrDefault();
            if (next == null)
            {
                RefreshQueueSummary();
                return;
            }

            _orderRepo.UpdateOrderStatus(next.OrderId, OrderStatus.OnTheWay);

            MessageBox.Show(
                $"Order #{next.OrderId} is now marked as 'On the way'.",
                "Queue",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            RefreshGrid();
        }

        private int? GetSelectedCourierIdOrNull()
        {
            if (cmbCourier.SelectedValue is int id)
            {
                if (id <= 0) return null;
                return id;
            }

            return null;
        }

        private static Rectangle GetEditButtonRect(Rectangle cellRect)
        {
            var buttonWidth = cellRect.Width - 10;
            var buttonHeight = cellRect.Height - 8;

            return new Rectangle(
                cellRect.Left + 4,
                cellRect.Top + 4,
                buttonWidth,
                buttonHeight
            );
        }

        private void gridOrders_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            if (e.ColumnIndex >= gridOrders.Columns.Count) return;

            if (gridOrders.Columns[e.ColumnIndex].Name != "actions")
                return;

            e.PaintBackground(e.ClipBounds, true);

            if (e.Graphics == null) return;

            var rect = GetEditButtonRect(e.CellBounds);

            ButtonRenderer.DrawButton(
                e.Graphics,
                rect,
                "Edit",
                gridOrders.Font,
                false,
                PushButtonState.Default
            );

            e.Handled = true;
        }

        private void gridOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            if (e.ColumnIndex >= gridOrders.Columns.Count) return;

            if (gridOrders.Columns[e.ColumnIndex].Name != "actions")
                return;

            var cellRect = gridOrders.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            var clickPoint = new Point(cellRect.Left + e.X, cellRect.Top + e.Y);

            var editRect = GetEditButtonRect(cellRect);

            if (!editRect.Contains(clickPoint))
                return;

            var idObj = gridOrders.Rows[e.RowIndex].Cells["order_id"].Value;
            if (idObj == null) return;

            var id = Convert.ToInt64(idObj);
            EditRequested?.Invoke(this, id);
        }
    }
}
