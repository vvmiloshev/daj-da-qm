using SDA_559ir.Data;
using SDA_559ir.Models;

namespace SDA_559ir.Views
{
    public partial class NewOrderAssignmentTabView : UserControl
    {
        private readonly NewOrderDraft _draft;

        private readonly CourierRepository _courierRepo = new CourierRepository();
        private readonly OrderRepository _orderRepo = new OrderRepository();

        public event EventHandler<long>? OrderSaved;

        public NewOrderAssignmentTabView(NewOrderDraft draft)
        {
            InitializeComponent();
            _draft = draft;

            Load += NewOrderAssignmentTabView_Load;
            btnSaveOrder.Click += btnSaveOrder_Click;
        }

        private void NewOrderAssignmentTabView_Load(object? sender, EventArgs e)
        {
            LoadCouriers();
            LoadStatuses();

            if (!_draft.DeliverAt.HasValue)
                _draft.DeliverAt = DateTime.Now.AddMinutes(45);

            dtpDeliverAt.Value = _draft.DeliverAt.Value;

            cmbStatus.SelectedValue = (int)_draft.Status;

            if (_draft.CourierId.HasValue)
                cmbCourier.SelectedValue = _draft.CourierId.Value;

            // Optional: change button text when editing existing order
            btnSaveOrder.Text = _draft.OrderId.HasValue ? "Update" : "Save";
        }

        private void LoadCouriers()
        {
            var list = _courierRepo.GetAll(null, true);

            cmbCourier.DisplayMember = "Name";
            cmbCourier.ValueMember = "Id";
            cmbCourier.DataSource = list;

            // If no couriers exist, keep it empty and validation will handle it on Save
        }

        private void LoadStatuses()
        {
            var items = new List<StatusItem>
            {
                new StatusItem((int)OrderStatus.New, "New"),
                new StatusItem((int)OrderStatus.OnTheWay, "On the way"),
                new StatusItem((int)OrderStatus.Completed, "Completed")
            };

            cmbStatus.DisplayMember = "Text";
            cmbStatus.ValueMember = "Value";
            cmbStatus.DataSource = items;
        }

        private void btnSaveOrder_Click(object? sender, EventArgs e)
        {
            if (_draft.ItemsByMenuItemId.Count == 0)
            {
                MessageBox.Show("Select at least 1 product.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_draft.DeliveryAddress) ||
                string.IsNullOrWhiteSpace(_draft.CustomerName) ||
                string.IsNullOrWhiteSpace(_draft.CustomerPhone))
            {
                MessageBox.Show("Delivery info is incomplete. Fill name, phone and address first.");
                return;
            }

            if (cmbCourier.SelectedValue is not int courierId)
            {
                MessageBox.Show("Select a courier.");
                return;
            }

            if (cmbStatus.SelectedValue is not int statusValue)
            {
                MessageBox.Show("Select a status.");
                return;
            }

            _draft.CourierId = courierId;
            _draft.DeliverAt = dtpDeliverAt.Value;
            _draft.Status = (OrderStatus)statusValue;

            try
            {
                // Create when OrderId is null, Update when OrderId has value
                var orderId = _orderRepo.SaveOrder(_draft);

                // Ensure draft holds the id (SaveOrder already sets it, but keep it explicit)
                _draft.OrderId = orderId;

                btnSaveOrder.Text = "Update";

                OrderSaved?.Invoke(this, orderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save failed: {ex.Message}");
            }
        }

        private sealed class StatusItem
        {
            public int Value { get; }
            public string Text { get; }

            public StatusItem(int value, string text)
            {
                Value = value;
                Text = text;
            }
        }
    }
}
