namespace SDA_559ir.Views.Controls
{
    partial class MenuItemCardView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Panel textPanel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.FlowLayoutPanel actionsPanel;
        private SDA_559ir.Views.Controls.QuantityPicker qty;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cardPanel = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.textPanel = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.actionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.qty = new SDA_559ir.Views.Controls.QuantityPicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.textPanel.SuspendLayout();
            this.actionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardPanel
            // 
            this.cardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanel.Controls.Add(this.actionsPanel);
            this.cardPanel.Controls.Add(this.textPanel);
            this.cardPanel.Controls.Add(this.pic);
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.Location = new System.Drawing.Point(0, 0);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Padding = new System.Windows.Forms.Padding(10);
            this.cardPanel.Size = new System.Drawing.Size(900, 100);
            this.cardPanel.TabIndex = 0;
            // 
            // pic
            // 
            this.pic.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic.Location = new System.Drawing.Point(10, 10);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(80, 78);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // textPanel
            // 
            this.textPanel.Controls.Add(this.lblDesc);
            this.textPanel.Controls.Add(this.lblName);
            this.textPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPanel.Location = new System.Drawing.Point(90, 10);
            this.textPanel.Name = "textPanel";
            this.textPanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.textPanel.Size = new System.Drawing.Size(560, 78);
            this.textPanel.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(10, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(540, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Product name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesc
            // 
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.Location = new System.Drawing.Point(10, 24);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(540, 54);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "Description";
            // 
            // actionsPanel
            // 
            this.actionsPanel.Controls.Add(this.qty);
            this.actionsPanel.Controls.Add(this.btnDelete);
            this.actionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.actionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.actionsPanel.Location = new System.Drawing.Point(650, 10);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.actionsPanel.Size = new System.Drawing.Size(238, 78);
            this.actionsPanel.TabIndex = 2;
            this.actionsPanel.WrapContents = false;
            // 
            // qty
            // 
            this.qty.Location = new System.Drawing.Point(3, 23);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(150, 32);
            this.qty.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(159, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 32);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // MenuItemCardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cardPanel);
            this.Name = "MenuItemCardView";
            this.Size = new System.Drawing.Size(900, 100);
            this.cardPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.textPanel.ResumeLayout(false);
            this.actionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
