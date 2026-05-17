using SDA_559ir.Models;

namespace SDA_559ir.Views
{
    public partial class NewOrderDeliveryTabView : UserControl
    {
        private readonly NewOrderDraft _draft;

        public event EventHandler? NextRequested;

        public NewOrderDeliveryTabView(NewOrderDraft draft)
        {
            InitializeComponent();
            _draft = draft;

            Load += NewOrderDeliveryTabView_Load;

            WireNextButtonsIfExist();
        }

        private void WireNextButtonsIfExist()
        {
            var top = FindButton("btnNextTop");
            var bottom = FindButton("btnNextBottom");

            if (top != null) top.Click += NextClick;
            if (bottom != null) bottom.Click += NextClick;
        }

        private Button? FindButton(string name)
        {
            var found = Controls.Find(name, true);
            if (found.Length == 0) return null;
            return found[0] as Button;
        }

        private void NewOrderDeliveryTabView_Load(object? sender, EventArgs e)
        {
            txtCustomerName.Text = _draft.CustomerName;
            txtCustomerPhone.Text = _draft.CustomerPhone;
            txtAddress.Text = _draft.DeliveryAddress;
        }

        private void NextClick(object? sender, EventArgs e)
        {
            _draft.CustomerName = (txtCustomerName.Text ?? "").Trim();
            _draft.CustomerPhone = (txtCustomerPhone.Text ?? "").Trim();
            _draft.DeliveryAddress = (txtAddress.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(_draft.DeliveryAddress))
            {
                MessageBox.Show("Address is required.");
                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(_draft.CustomerName))
            {
                MessageBox.Show("Name is required.");
                txtCustomerName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(_draft.CustomerPhone))
            {
                MessageBox.Show("Phone is required.");
                txtCustomerPhone.Focus();
                return;
            }

            NextRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
