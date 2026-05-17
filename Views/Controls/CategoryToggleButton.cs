using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VSP__559ir_MyProject.Views.Controls
{
    public class CategoryToggleButton : Button
    {
        public bool IsToggled { get; private set; }

        public void SetToggled(bool toggled)
        {
            IsToggled = toggled;
            UpdateStyle();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 1;
            Height = 36;
            Width = 120;

            UpdateStyle();
            //ApplyRounded(16);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //ApplyRounded(16);
        }

        private void UpdateStyle()
        {
            Font = new Font(Font, IsToggled ? FontStyle.Bold : FontStyle.Regular);
        }

        private void ApplyRounded(int radius)
        {
            if (Width <= 0 || Height <= 0) return;

            var path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(Width - d, 0, d, d, 270, 90);
            path.AddArc(Width - d, Height - d, d, d, 0, 90);
            path.AddArc(0, Height - d, d, d, 90, 90);
            path.CloseFigure();

            Region = new Region(path);
        }
    }
}
