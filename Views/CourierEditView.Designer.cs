namespace SDA_559ir.Views
{
    partial class CourierEditView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            table = new TableLayoutPanel();
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            chkActive = new CheckBox();
            buttonsPanel = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            table.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.Controls.Add(lblTitle, 0, 0);
            table.Controls.Add(lblName, 0, 1);
            table.Controls.Add(txtName, 1, 1);
            table.Controls.Add(lblPhone, 0, 2);
            table.Controls.Add(txtPhone, 1, 2);
            table.Controls.Add(chkActive, 1, 3);
            table.Controls.Add(buttonsPanel, 1, 4);
            table.Dock = DockStyle.Top;
            table.Location = new Point(0, 0);
            table.Margin = new Padding(3, 4, 3, 4);
            table.Name = "table";
            table.Padding = new Padding(18, 21, 18, 21);
            table.RowCount = 5;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            table.Size = new Size(1029, 347);
            table.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            table.SetColumnSpan(lblTitle, 2);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(21, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(987, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Courier";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            lblName.Dock = DockStyle.Fill;
            lblName.Location = new Point(21, 85);
            lblName.Name = "lblName";
            lblName.Size = new Size(154, 59);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(181, 100);
            txtName.Margin = new Padding(3, 15, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(827, 27);
            txtName.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.Dock = DockStyle.Fill;
            lblPhone.Location = new Point(21, 144);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(154, 59);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone";
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Location = new Point(181, 159);
            txtPhone.Margin = new Padding(3, 15, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(827, 27);
            txtPhone.TabIndex = 4;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Location = new Point(181, 207);
            chkActive.Margin = new Padding(3, 4, 3, 4);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(72, 24);
            chkActive.TabIndex = 5;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(btnSave);
            buttonsPanel.Controls.Add(btnCancel);
            buttonsPanel.Dock = DockStyle.Left;
            buttonsPanel.Location = new Point(178, 256);
            buttonsPanel.Margin = new Padding(0);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(389, 70);
            buttonsPanel.TabIndex = 6;
            buttonsPanel.WrapContents = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(3, 13);
            btnSave.Margin = new Padding(3, 13, 9, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 43);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(152, 13);
            btnCancel.Margin = new Padding(3, 13, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 43);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // CourierEditView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(table);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CourierEditView";
            Size = new Size(1029, 800);
            table.ResumeLayout(false);
            table.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
