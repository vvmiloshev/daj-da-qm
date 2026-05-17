namespace VSP__559ir_MyProject.Views
{
    partial class HomeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeView));
            flowLayoutPanel1 = new FlowLayoutPanel();
            ordersButton = new Button();
            newOrderButton = new Button();
            menuButton = new Button();
            couriersButton = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(ordersButton);
            flowLayoutPanel1.Controls.Add(newOrderButton);
            flowLayoutPanel1.Controls.Add(menuButton);
            flowLayoutPanel1.Controls.Add(couriersButton);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1006, 633);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // ordersButton
            // 
            ordersButton.BackgroundImage = (Image)resources.GetObject("ordersButton.BackgroundImage");
            ordersButton.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ordersButton.Location = new Point(10, 10);
            ordersButton.Margin = new Padding(10);
            ordersButton.Name = "ordersButton";
            ordersButton.Size = new Size(200, 200);
            ordersButton.TabIndex = 0;
            ordersButton.Text = "Поръчки";
            ordersButton.UseVisualStyleBackColor = true;
            ordersButton.Click += ordersButton_Click;
            // 
            // newOrderButton
            // 
            newOrderButton.BackgroundImage = (Image)resources.GetObject("newOrderButton.BackgroundImage");
            newOrderButton.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            newOrderButton.Location = new Point(230, 10);
            newOrderButton.Margin = new Padding(10);
            newOrderButton.Name = "newOrderButton";
            newOrderButton.Size = new Size(200, 200);
            newOrderButton.TabIndex = 1;
            newOrderButton.Text = "Нова Поръчка";
            newOrderButton.UseVisualStyleBackColor = true;
            newOrderButton.Click += newOrderButton_Click;
            // 
            // menuButton
            // 
            menuButton.BackgroundImage = (Image)resources.GetObject("menuButton.BackgroundImage");
            menuButton.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            menuButton.Location = new Point(450, 10);
            menuButton.Margin = new Padding(10);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(200, 200);
            menuButton.TabIndex = 2;
            menuButton.Text = "Меню";
            menuButton.UseVisualStyleBackColor = true;
            menuButton.Click += menuButton_Click;
            // 
            // couriersButton
            // 
            couriersButton.BackgroundImage = (Image)resources.GetObject("couriersButton.BackgroundImage");
            couriersButton.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            couriersButton.Location = new Point(670, 10);
            couriersButton.Margin = new Padding(10);
            couriersButton.Name = "couriersButton";
            couriersButton.Size = new Size(200, 200);
            couriersButton.TabIndex = 3;
            couriersButton.Text = "Доставчици";
            couriersButton.UseVisualStyleBackColor = true;
            couriersButton.Click += couriersButton_Click;
            // 
            // HomeView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(flowLayoutPanel1);
            Name = "HomeView";
            Size = new Size(1006, 633);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button ordersButton;
        private Button newOrderButton;
        private Button menuButton;
        private Button couriersButton;
    }
}
