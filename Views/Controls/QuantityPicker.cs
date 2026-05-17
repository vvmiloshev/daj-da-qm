using System;
using System.ComponentModel;

namespace VSP__559ir_MyProject.Views.Controls
{
    public partial class QuantityPicker : UserControl
    {
        public event EventHandler<int>? ValueChanged;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Value
        {
            get => (int)num.Value;
            set
            {
                var v = Math.Max((int)num.Minimum, Math.Min((int)num.Maximum, value));
                num.Value = v;
                UpdateUi();
            }
        }

        public QuantityPicker()
        {
            InitializeComponent();

            btnMinus.Click += btnMinus_Click;
            btnPlus.Click += btnPlus_Click;
            num.ValueChanged += num_ValueChanged;

            UpdateUi();
        }

        private void btnMinus_Click(object? sender, EventArgs e)
        {
            if (Value > 0) Value--;
            ValueChanged?.Invoke(this, Value);
        }

        private void btnPlus_Click(object? sender, EventArgs e)
        {
            Value++;
            ValueChanged?.Invoke(this, Value);
        }

        private void num_ValueChanged(object? sender, EventArgs e)
        {
            UpdateUi();
            ValueChanged?.Invoke(this, Value);
        }

        private void UpdateUi()
        {
            btnMinus.Enabled = Value > 0;
        }
    }
}
