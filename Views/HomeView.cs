using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VSP__559ir_MyProject.Views
{
    public partial class HomeView : UserControl
    {
        public event EventHandler? MenuRequested;
        public event EventHandler? OrdersRequested;
        public event EventHandler? NewOrderRequested;
        public event EventHandler? CouriersRequested;

        public HomeView()
        {
            InitializeComponent();

            // Apply rounded corners after control is shown and has valid sizes
            //this.VisibleChanged += HomeView_VisibleChanged;
        }

        private void HomeView_VisibleChanged(object? sender, EventArgs e)
        {
            if (!this.Visible) return;

            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Button b)
                    RoundButton(b, 20);
            }
        }

        private static void RoundButton(Button btn, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(btn.Width - d, 0, d, d, 270, 90);
            path.AddArc(btn.Width - d, btn.Height - d, d, d, 0, 90);
            path.AddArc(0, btn.Height - d, d, d, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            MenuRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ordersButton_Click(object sender, EventArgs e)
        {
            OrdersRequested?.Invoke(this, EventArgs.Empty);
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            NewOrderRequested?.Invoke(this, EventArgs.Empty);
        }

        private void couriersButton_Click(object sender, EventArgs e)
        {
            CouriersRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
