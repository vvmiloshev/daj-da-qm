namespace SDA_559ir.Views
{
    partial class NewOrderAssignmentTabView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblCourier;
        private System.Windows.Forms.ComboBox cmbCourier;

        private System.Windows.Forms.Label lblDeliverAt;
        private System.Windows.Forms.DateTimePicker dtpDeliverAt;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;

        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button btnSaveOrder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCourier = new System.Windows.Forms.Label();
            this.cmbCourier = new System.Windows.Forms.ComboBox();
            this.lblDeliverAt = new System.Windows.Forms.Label();
            this.dtpDeliverAt = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.table.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.lblTitle, 0, 0);
            this.table.Controls.Add(this.lblCourier, 0, 1);
            this.table.Controls.Add(this.cmbCourier, 1, 1);
            this.table.Controls.Add(this.lblDeliverAt, 0, 2);
            this.table.Controls.Add(this.dtpDeliverAt, 1, 2);
            this.table.Controls.Add(this.lblStatus, 0, 3);
            this.table.Controls.Add(this.cmbStatus, 1, 3);
            this.table.Controls.Add(this.buttonsPanel, 1, 4);
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(16);
            this.table.RowCount = 5;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.table.Size = new System.Drawing.Size(972, 300);
            this.table.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.table.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(19, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(934, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Courier, time and status";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCourier
            // 
            this.lblCourier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCourier.Location = new System.Drawing.Point(19, 64);
            this.lblCourier.Name = "lblCourier";
            this.lblCourier.Size = new System.Drawing.Size(154, 44);
            this.lblCourier.TabIndex = 1;
            this.lblCourier.Text = "Courier";
            this.lblCourier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCourier
            // 
            this.cmbCourier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCourier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourier.FormattingEnabled = true;
            this.cmbCourier.Location = new System.Drawing.Point(179, 75);
            this.cmbCourier.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.cmbCourier.Name = "cmbCourier";
            this.cmbCourier.Size = new System.Drawing.Size(774, 23);
            this.cmbCourier.TabIndex = 2;
            // 
            // lblDeliverAt
            // 
            this.lblDeliverAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeliverAt.Location = new System.Drawing.Point(19, 108);
            this.lblDeliverAt.Name = "lblDeliverAt";
            this.lblDeliverAt.Size = new System.Drawing.Size(154, 44);
            this.lblDeliverAt.TabIndex = 3;
            this.lblDeliverAt.Text = "Deliver at";
            this.lblDeliverAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDeliverAt
            // 
            this.dtpDeliverAt.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpDeliverAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliverAt.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDeliverAt.Location = new System.Drawing.Point(179, 119);
            this.dtpDeliverAt.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.dtpDeliverAt.Name = "dtpDeliverAt";
            this.dtpDeliverAt.Size = new System.Drawing.Size(220, 23);
            this.dtpDeliverAt.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(19, 152);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(154, 44);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(179, 163);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(220, 23);
            this.cmbStatus.TabIndex = 6;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.buttonsPanel.Location = new System.Drawing.Point(176, 196);
            this.buttonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.buttonsPanel.Size = new System.Drawing.Size(360, 60);
            this.buttonsPanel.TabIndex = 7;
            this.buttonsPanel.WrapContents = false;
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Location = new System.Drawing.Point(3, 13);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(160, 32);
            this.btnSaveOrder.TabIndex = 0;
            this.btnSaveOrder.Text = "Save order";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.buttonsPanel.Controls.Add(this.btnSaveOrder);
            // 
            // NewOrderAssignmentTabView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Name = "NewOrderAssignmentTabView";
            this.Size = new System.Drawing.Size(972, 616);
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
