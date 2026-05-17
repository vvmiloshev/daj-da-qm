namespace SDA_559ir.Views
{
    partial class NewOrderProductsTabView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel layoutRoot;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnNextTop;

        private System.Windows.Forms.FlowLayoutPanel flpCategories;

        private System.Windows.Forms.FlowLayoutPanel flpProducts;

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button btnNextBottom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.layoutRoot = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnNextTop = new System.Windows.Forms.Button();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.btnNextBottom = new System.Windows.Forms.Button();
            this.layoutRoot.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutRoot
            // 
            this.layoutRoot.ColumnCount = 1;
            this.layoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRoot.Controls.Add(this.topPanel, 0, 0);
            this.layoutRoot.Controls.Add(this.flpProducts, 0, 1);
            this.layoutRoot.Controls.Add(this.bottomPanel, 0, 2);
            this.layoutRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRoot.Location = new System.Drawing.Point(0, 0);
            this.layoutRoot.Name = "layoutRoot";
            this.layoutRoot.RowCount = 3;
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.layoutRoot.Size = new System.Drawing.Size(1000, 600);
            this.layoutRoot.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.flpCategories);
            this.topPanel.Controls.Add(this.btnNextTop);
            this.topPanel.Controls.Add(this.lblHint);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(12);
            this.topPanel.Size = new System.Drawing.Size(994, 114);
            this.topPanel.TabIndex = 0;
            // 
            // lblHint
            // 
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.Location = new System.Drawing.Point(12, 12);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(970, 22);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "Choose category, then select quantities";
            // 
            // btnNextTop
            // 
            this.btnNextTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextTop.Location = new System.Drawing.Point(872, 44);
            this.btnNextTop.Name = "btnNextTop";
            this.btnNextTop.Size = new System.Drawing.Size(110, 34);
            this.btnNextTop.TabIndex = 1;
            this.btnNextTop.Text = "Next";
            this.btnNextTop.UseVisualStyleBackColor = true;
            // 
            // flpCategories
            // 
            this.flpCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCategories.AutoScroll = true;
            this.flpCategories.Location = new System.Drawing.Point(12, 44);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(850, 58);
            this.flpCategories.TabIndex = 2;
            this.flpCategories.WrapContents = false;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpProducts.Location = new System.Drawing.Point(3, 123);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(10);
            this.flpProducts.Size = new System.Drawing.Size(994, 404);
            this.flpProducts.TabIndex = 1;
            this.flpProducts.WrapContents = false;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.btnNextBottom);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 533);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(12);
            this.bottomPanel.Size = new System.Drawing.Size(994, 64);
            this.bottomPanel.TabIndex = 2;
            // 
            // btnNextBottom
            // 
            this.btnNextBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextBottom.Location = new System.Drawing.Point(872, 15);
            this.btnNextBottom.Name = "btnNextBottom";
            this.btnNextBottom.Size = new System.Drawing.Size(110, 34);
            this.btnNextBottom.TabIndex = 0;
            this.btnNextBottom.Text = "Next";
            this.btnNextBottom.UseVisualStyleBackColor = true;
            // 
            // NewOrderProductsTabView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutRoot);
            this.Name = "NewOrderProductsTabView";
            this.Size = new System.Drawing.Size(1000, 600);
            this.layoutRoot.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
