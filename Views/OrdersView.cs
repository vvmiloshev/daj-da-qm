using System.Windows.Forms.VisualStyles;
using VSP__559ir_MyProject.Data;
using VSP__559ir_MyProject.Models;

namespace VSP__559ir_MyProject.Views
{
    public partial class OrdersView : UserControl
    {
        public event EventHandler? BackRequested;
        public event EventHandler<long>? EditRequested;

        private readonly OrderRepository _orderRepo = new OrderRepository();
        private readonly CourierRepository _courierRepo = new CourierRepository();

        private readonly System.Windows.Forms.Timer _searchTimer = new System.Windows.Forms.Timer();

        public OrdersView()
        {
            InitializeComponent();
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
