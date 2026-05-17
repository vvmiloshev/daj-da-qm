namespace SDA_559ir.Views
{
    partial class MenuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            topPanel = new Panel();
            backButton = new Button();
            newProductButton = new Button();
            gridMenu = new DataGridView();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridMenu).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackgroundImage = (Image)resources.GetObject("topPanel.BackgroundImage");
            topPanel.Controls.Add(backButton);
            topPanel.Controls.Add(newProductButton);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(10);
            topPanel.Size = new Size(1006, 60);
            topPanel.TabIndex = 0;
            // 
            // backButton
            // 
            backButton.Location = new Point(10, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(90, 30);
            backButton.TabIndex = 0;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // newProductButton
            // 
            newProductButton.Location = new Point(110, 12);
            newProductButton.Name = "newProductButton";
            newProductButton.Size = new Size(120, 30);
            newProductButton.TabIndex = 1;
            newProductButton.Text = "Нов продукт";
            newProductButton.UseVisualStyleBackColor = true;
            newProductButton.Click += newProductButton_Click;
            // 
            // gridMenu
            // 
            gridMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMenu.Dock = DockStyle.Fill;
            gridMenu.Location = new Point(0, 60);
            gridMenu.Name = "gridMenu";
            gridMenu.RowHeadersWidth = 51;
            gridMenu.Size = new Size(1006, 573);
            gridMenu.TabIndex = 1;
            // 
            // MenuView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridMenu);
            Controls.Add(topPanel);
            Name = "MenuView";
            Size = new Size(1006, 633);
            topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Button backButton;
        private Button newProductButton;
        private DataGridView gridMenu;
    }
}
