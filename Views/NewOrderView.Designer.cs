namespace SDA_559ir.Views
{
    partial class NewOrderView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.TabPage tabPageDelivery;
        private System.Windows.Forms.TabPage tabPageAssignment;
        private System.Windows.Forms.TabPage tabPagePreview;

        // Prevent manual tab switching by click
        private bool _allowTabChange = false;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.tabPageDelivery = new System.Windows.Forms.TabPage();
            this.tabPageAssignment = new System.Windows.Forms.TabPage();
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.topPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.btnBack);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(12);
            this.topPanel.Size = new System.Drawing.Size(980, 56);
            this.topPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(860, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "New Order";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.Location = new System.Drawing.Point(872, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 32);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageProducts);
            this.tabControl1.Controls.Add(this.tabPageDelivery);
            this.tabControl1.Controls.Add(this.tabPageAssignment);
            this.tabControl1.Controls.Add(this.tabPagePreview);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 56);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 644);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Location = new System.Drawing.Point(4, 24);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageProducts.Size = new System.Drawing.Size(972, 616);
            this.tabPageProducts.TabIndex = 0;
            this.tabPageProducts.Text = "Products";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            // 
            // tabPageDelivery
            // 
            this.tabPageDelivery.Location = new System.Drawing.Point(4, 24);
            this.tabPageDelivery.Name = "tabPageDelivery";
            this.tabPageDelivery.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageDelivery.Size = new System.Drawing.Size(972, 616);
            this.tabPageDelivery.TabIndex = 1;
            this.tabPageDelivery.Text = "Delivery";
            this.tabPageDelivery.UseVisualStyleBackColor = true;
            // 
            // tabPageAssignment
            // 
            this.tabPageAssignment.Location = new System.Drawing.Point(4, 24);
            this.tabPageAssignment.Name = "tabPageAssignment";
            this.tabPageAssignment.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageAssignment.Size = new System.Drawing.Size(972, 616);
            this.tabPageAssignment.TabIndex = 2;
            this.tabPageAssignment.Text = "Assign";
            this.tabPageAssignment.UseVisualStyleBackColor = true;
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.Enabled = false;
            this.tabPagePreview.Location = new System.Drawing.Point(4, 24);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(6);
            this.tabPagePreview.Size = new System.Drawing.Size(972, 616);
            this.tabPagePreview.TabIndex = 3;
            this.tabPagePreview.Text = "Preview";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // NewOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.topPanel);
            this.Name = "NewOrderView";
            this.Size = new System.Drawing.Size(980, 700);
            this.topPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

    }
}
