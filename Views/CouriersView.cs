using VSP__559ir_MyProject.Data;
using VSP__559ir_MyProject.Models;

namespace VSP__559ir_MyProject.Views
{
    public partial class CouriersView : UserControl
    {
        private readonly CourierRepository _repo = new CourierRepository();

        public event EventHandler? BackRequested;
        public event EventHandler? AddRequested;
        public event EventHandler<int>? EditRequested;

        public CouriersView()
        {
            InitializeComponent();
            Load += CouriersView_Load;
        }

        private void CouriersView_Load(object? sender, EventArgs e)
        {
            dgvCouriers.ReadOnly = true;
            dgvCouriers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCouriers.MultiSelect = false;
            dgvCouriers.AutoGenerateColumns = true;

            chkOnlyActive.Checked = true;
            RefreshGrid();
        }

        public void RefreshGrid()
        {
            var data = _repo.GetAll(txtSearch.Text, chkOnlyActive.Checked);
            dgvCouriers.DataSource = data;

            if (dgvCouriers.Columns["Id"] != null) dgvCouriers.Columns["Id"].HeaderText = "ID";
            if (dgvCouriers.Columns["Name"] != null) dgvCouriers.Columns["Name"].HeaderText = "Name";
            if (dgvCouriers.Columns["Phone"] != null) dgvCouriers.Columns["Phone"].HeaderText = "Phone";
            if (dgvCouriers.Columns["IsActive"] != null) dgvCouriers.Columns["IsActive"].HeaderText = "Active";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => RefreshGrid();
        private void chkOnlyActive_CheckedChanged(object sender, EventArgs e) => RefreshGrid();

        private void btnBack_Click(object sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);
        private void btnAdd_Click(object sender, EventArgs e) => AddRequested?.Invoke(this, EventArgs.Empty);

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();
            if (id == null) return;

            EditRequested?.Invoke(this, id.Value);
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();
            if (id == null) return;

            var confirm = MessageBox.Show(
                "Deactivate selected courier?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirm != DialogResult.Yes) return;

            _repo.Deactivate(id.Value);
            RefreshGrid();
        }

        private int? GetSelectedId()
        {
            if (dgvCouriers.CurrentRow?.DataBoundItem is Courier c) return c.Id;
            return null;
        }
    }
}
