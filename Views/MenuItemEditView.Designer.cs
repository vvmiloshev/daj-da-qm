namespace VSP__559ir_MyProject.Views
{
    partial class MenuItemEditView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            formPanel = new Panel();
            titleLabel = new Label();
            labelName = new Label();
            txtName = new TextBox();
            labelCategory = new Label();
            cmbCategory = new ComboBox();
            labelDescription = new Label();
            txtDescription = new TextBox();
            labelWeight = new Label();
            txtWeightGrams = new TextBox();
            labelPrice = new Label();
            txtPriceEur = new TextBox();
            picImage = new PictureBox();
            btnChooseImage = new Button();
            buttonsPanel = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            mainPanel.SuspendLayout();
            formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(formPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(1006, 633);
            mainPanel.TabIndex = 0;
            // 
            // formPanel
            // 
            formPanel.Controls.Add(buttonsPanel);
            formPanel.Controls.Add(btnChooseImage);
            formPanel.Controls.Add(picImage);
            formPanel.Controls.Add(txtPriceEur);
            formPanel.Controls.Add(labelPrice);
            formPanel.Controls.Add(txtWeightGrams);
            formPanel.Controls.Add(labelWeight);
            formPanel.Controls.Add(txtDescription);
            formPanel.Controls.Add(labelDescription);
            formPanel.Controls.Add(cmbCategory);
            formPanel.Controls.Add(labelCategory);
            formPanel.Controls.Add(txtName);
            formPanel.Controls.Add(labelName);
            formPanel.Controls.Add(titleLabel);
            formPanel.Dock = DockStyle.Top;
            formPanel.Location = new Point(20, 20);
            formPanel.Name = "formPanel";
            formPanel.Padding = new Padding(20);
            formPanel.Size = new Size(966, 520);
            formPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            titleLabel.Location = new Point(20, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(155, 36);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Продукт";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelName.Location = new Point(20, 80);
            labelName.Name = "labelName";
            labelName.Size = new Size(46, 24);
            labelName.TabIndex = 1;
            labelName.Text = "Име";
            // 
            // txtName
            // 
            txtName.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtName.Location = new Point(20, 110);
            txtName.Name = "txtName";
            txtName.Size = new Size(520, 32);
            txtName.TabIndex = 2;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelCategory.Location = new Point(20, 155);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(99, 24);
            labelCategory.TabIndex = 3;
            labelCategory.Text = "Категория";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(20, 185);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(520, 32);
            cmbCategory.TabIndex = 4;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelDescription.Location = new Point(20, 230);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(97, 24);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Описание";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDescription.Location = new Point(20, 260);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(520, 120);
            txtDescription.TabIndex = 6;
            // 
            // labelWeight
            // 
            labelWeight.AutoSize = true;
            labelWeight.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelWeight.Location = new Point(20, 395);
            labelWeight.Name = "labelWeight";
            labelWeight.Size = new Size(78, 24);
            labelWeight.TabIndex = 7;
            labelWeight.Text = "Грамаж";
            // 
            // txtWeightGrams
            // 
            txtWeightGrams.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtWeightGrams.Location = new Point(20, 425);
            txtWeightGrams.Name = "txtWeightGrams";
            txtWeightGrams.PlaceholderText = "grams";
            txtWeightGrams.Size = new Size(250, 32);
            txtWeightGrams.TabIndex = 8;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelPrice.Location = new Point(290, 395);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(109, 24);
            labelPrice.TabIndex = 9;
            labelPrice.Text = "Цена (EUR)";
            // 
            // txtPriceEur
            // 
            txtPriceEur.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPriceEur.Location = new Point(290, 425);
            txtPriceEur.Name = "txtPriceEur";
            txtPriceEur.PlaceholderText = "EUR";
            txtPriceEur.Size = new Size(250, 32);
            txtPriceEur.TabIndex = 10;
            // 
            // picImage
            // 
            picImage.BorderStyle = BorderStyle.FixedSingle;
            picImage.Location = new Point(570, 110);
            picImage.Name = "picImage";
            picImage.Size = new Size(360, 270);
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.TabIndex = 11;
            picImage.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(570, 395);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(360, 35);
            btnChooseImage.TabIndex = 12;
            btnChooseImage.Text = "Избери снимка";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(btnCancel);
            buttonsPanel.Controls.Add(btnSave);
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.Location = new Point(20, 470);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(926, 30);
            buttonsPanel.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Location = new Point(746, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Запази";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Location = new Point(841, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отказ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // MenuItemEditView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Name = "MenuItemEditView";
            Size = new Size(1006, 633);
            mainPanel.ResumeLayout(false);
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel formPanel;

        private Label titleLabel;

        private Label labelName;
        private TextBox txtName;

        private Label labelCategory;
        private ComboBox cmbCategory;

        private Label labelDescription;
        private TextBox txtDescription;

        private Label labelWeight;
        private TextBox txtWeightGrams;

        private Label labelPrice;
        private TextBox txtPriceEur;

        private PictureBox picImage;
        private Button btnChooseImage;

        private Panel buttonsPanel;
        private Button btnSave;
        private Button btnCancel;
    }
}
