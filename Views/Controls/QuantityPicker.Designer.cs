namespace VSP__559ir_MyProject.Views.Controls
{
    partial class QuantityPicker
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.NumericUpDown num;
        private System.Windows.Forms.Button btnPlus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnMinus = new System.Windows.Forms.Button();
            this.num = new System.Windows.Forms.NumericUpDown();
            this.btnPlus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(0, 0);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(32, 32);
            this.btnMinus.TabIndex = 0;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(34, 4);
            this.num.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(70, 23);
            this.num.TabIndex = 1;
            this.num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(106, 0);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(32, 32);
            this.btnPlus.TabIndex = 2;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            // 
            // QuantityPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.num);
            this.Controls.Add(this.btnMinus);
            this.Name = "QuantityPicker";
            this.Size = new System.Drawing.Size(138, 32);
            ((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
