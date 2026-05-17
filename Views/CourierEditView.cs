using Microsoft.Data.Sqlite;
using System.Xml.Linq;
using VSP__559ir_MyProject.Data;
using VSP__559ir_MyProject.Models;

namespace VSP__559ir_MyProject.Views
{
    public partial class CourierEditView : UserControl
    {
        private readonly CourierRepository _repo = new CourierRepository();
        private readonly int? _id;

        public event EventHandler? CancelRequested;
        public event EventHandler? Saved;

        public CourierEditView(int? id)
        {
            InitializeComponent();
            _id = id;
            Load += CourierEditView_Load;
        }

        private void CourierEditView_Load(object? sender, EventArgs e)
        {
            chkActive.Checked = true;

            if (_id == null) return;

            var c = _repo.GetById(_id.Value);
            if (c == null)
            {
                MessageBox.Show("Courier not found.");
                CancelRequested?.Invoke(this, EventArgs.Empty);
                return;
            }

            txtName.Text = c.Name;
            txtPhone.Text = c.Phone;
            chkActive.Checked = c.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = (txtName.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is required.");
                txtName.Focus();
                return;
            }

            var model = new Courier
            {
                Id = _id ?? 0,
                Name = name,
                Phone = (txtPhone.Text ?? "").Trim(),
                IsActive = chkActive.Checked
            };

            try
            {
                if (_id == null) _repo.Create(model);
                else _repo.Update(model);

                Saved?.Invoke(this, EventArgs.Empty);
            }
            catch (SqliteException ex)
            {
                MessageBox.Show($"Save failed: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
