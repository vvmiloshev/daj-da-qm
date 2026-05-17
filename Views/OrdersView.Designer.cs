namespace SDA_559ir.Views
{
    partial class OrdersView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.Label lblCourier;
        private System.Windows.Forms.ComboBox cmbCourier;

        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.DataGridView gridOrders;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCourier = new System.Windows.Forms.Label();
            this.cmbCourier = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.btnClear);
            this.topPanel.Controls.Add(this.cmbCourier);
            this.topPanel.Controls.Add(this.lblCourier);
            this.topPanel.Controls.Add(this.txtSearch);
            this.topPanel.Controls.Add(this.lblSearch);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.btnBack);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(12);
            this.topPanel.Size = new System.Drawing.Size(1000, 90);
            this.topPanel.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 29);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(120, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 29);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Orders";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(120, 52);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(60, 24);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(180, 52);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(360, 27);
            this.txtSearch.TabIndex = 3;
            // 
            // lblCourier
            // 
            this.lblCourier.Location = new System.Drawing.Point(550, 52);
            this.lblCourier.Name = "lblCourier";
            this.lblCourier.Size = new System.Drawing.Size(60, 24);
            this.lblCourier.TabIndex = 4;
            this.lblCourier.Text = "Courier";
            this.lblCourier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCourier
            // 
            this.cmbCourier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourier.FormattingEnabled = true;
            this.cmbCourier.Location = new System.Drawing.Point(610, 52);
            this.cmbCourier.Name = "cmbCourier";
            this.cmbCourier.Size = new System.Drawing.Size(210, 28);
            this.cmbCourier.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(830, 51);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 29);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // gridOrders
            // 
            this.gridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOrders.Location = new System.Drawing.Point(0, 90);
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.RowHeadersWidth = 51;
            this.gridOrders.RowTemplate.Height = 29;
            this.gridOrders.Size = new System.Drawing.Size(1000, 510);
            this.gridOrders.TabIndex = 1;
            // 
            // OrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridOrders);
            this.Controls.Add(this.topPanel);
            this.Name = "OrdersView";
            this.Size = new System.Drawing.Size(1000, 600);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
