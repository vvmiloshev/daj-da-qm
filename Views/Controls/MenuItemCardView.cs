using SDA_559ir.Models;

namespace SDA_559ir.Views.Controls
{
    public partial class MenuItemCardView : UserControl
    {
        public event EventHandler<int>? QtyChanged;
        public event EventHandler? DeleteRequested;

        public long MenuItemId { get; private set; }

        public MenuItemCardView()
        {
            InitializeComponent();

            btnDelete.Click += btnDelete_Click;

            qty.ValueChanged += (_, value) =>
            {
                UpdateDeleteVisibility();
                QtyChanged?.Invoke(this, value);
            };
        }

        public void Bind(MenuItem item, int currentQty)
        {
            MenuItemId = item.Id;

            lblName.Text = item.ProductName;
            lblDesc.Text = item.Description;

            LoadImage(item.ImagePath);

            qty.Value = currentQty;
            UpdateDeleteVisibility();
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            qty.Value = 0;
            UpdateDeleteVisibility();
            DeleteRequested?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateDeleteVisibility()
        {
            btnDelete.Visible = qty.Value > 0;
        }

        private void LoadImage(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    pic.Image = null;
                    return;
                }

                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                pic.Image = Image.FromStream(fs);
            }
            catch
            {
                pic.Image = null;
            }
        }
    }
}
