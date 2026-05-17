using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace VSP__559ir_MyProject
{
    partial class InitialScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialScreen));
            panelContent = new Panel();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1006, 633);
            panelContent.TabIndex = 0;
            // 
            // InitialScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 633);
            Controls.Add(panelContent);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InitialScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Дай да ям!";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
    }
}
