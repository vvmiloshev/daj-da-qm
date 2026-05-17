using SDA_559ir.Data;
using SDA_559ir.Models;

namespace SDA_559ir.Views
{
    /// <summary>
    /// View used to create or edit a menu item (product).
    /// /// Exposes events for cancel and save operations.
    /// </summary>
    public partial class MenuItemEditView : UserControl
    {
        /// <summary>
        /// Raised when the user cancels the edit/create operation.
        /// </summary>
        public event EventHandler? CancelRequested;
        /// <summary>
        /// Raised after the item has been successfully saved.
        /// </summary>
        public event EventHandler? Saved;

        private readonly MenuRepository _repo = new MenuRepository();
        private long? _editId = null;
        private string _imagePath = "";

        public MenuItemEditView()
        {
            InitializeComponent();
            LoadCategories();
        }

        /// <summary>
        /// Loads category list from repository and binds to the category combo box.
        /// </summary>
        private void LoadCategories()
        {
            var categories = _repo.GetCategories();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        /// <summary>
        /// Prepare the view for creating a new product.
        /// Clears input fields and places focus on the name field.
        /// </summary>
        public void InitForCreate()
        {
            _editId = null;
            titleLabel.Text = "Нов продукт";

            txtName.Text = "";
            txtDescription.Text = "";
            txtWeightGrams.Text = "";
            txtPriceEur.Text = "";

            _imagePath = "";
            picImage.Image = null;

            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;

            txtName.Focus();
        }


        /// <summary>
        /// Prepare the view for editing an existing product.
        /// Populates fields with the provided values and loads the image preview.
        /// </summary>
        public void InitForEdit(long id, string name, long categoryId, string description, double grams, double priceEur, string imagePath)
        {
            _editId = id;
            titleLabel.Text = "Редакция на продукт";

            txtName.Text = name ?? "";
            txtDescription.Text = description ?? "";
            txtWeightGrams.Text = grams.ToString();
            txtPriceEur.Text = priceEur.ToString();

            cmbCategory.SelectedValue = categoryId;

            _imagePath = imagePath ?? "";
            LoadImagePreview(_imagePath);

            txtName.Focus();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Bubble the cancel request to the host
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "Images|*.png;*.jpg;*.jpeg;*.webp;*.bmp";
            dlg.Title = "Избери снимка";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            // Copy image to app folder so we don't depend on external path
            _imagePath = CopyImageToAppFolder(dlg.FileName);
            LoadImagePreview(_imagePath);
        }

        /// <summary>
        /// Copies the selected image into an application-owned "images" directory.
        /// Uses a GUID-based filename to avoid collisions and returns the new path.
        /// </summary>
        private static string CopyImageToAppFolder(string sourcePath)
        {
            var imagesDir = Path.Combine(AppContext.BaseDirectory, "images");
            Directory.CreateDirectory(imagesDir);

            var ext = Path.GetExtension(sourcePath);
            var fileName = $"{Guid.NewGuid():N}{ext}";
            var destPath = Path.Combine(imagesDir, fileName);

            // Overwrite if a file with same name exists (unlikely because of GUID)
            File.Copy(sourcePath, destPath, true);
            return destPath;
        }

        /// <summary>
        /// Loads an image into the PictureBox without locking the source file.
        /// If the file is missing or invalid, clears the preview.
        /// </summary>
        private void LoadImagePreview(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    picImage.Image = null;
                    return;
                }

                // Avoid locking the file by cloning the bitmap
                using var bmpTemp = new Bitmap(path);
                picImage.Image = new Bitmap(bmpTemp);
            }
            catch
            {
                // On any failure (invalid image, IO error) show no preview
                picImage.Image = null;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate name
            var name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Моля въведи име.");
                txtName.Focus();
                return;
            }

            // Validate category selection
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Моля избери категория.");
                return;
            }

            // Validate weight (must be non-negative number)
            if (!double.TryParse(txtWeightGrams.Text.Trim(), out var grams) || grams < 0)
            {
                MessageBox.Show("Моля въведи валиден грамаж (число).");
                txtWeightGrams.Focus();
                return;
            }

            // Validate price (must be non-negative number)
            if (!double.TryParse(txtPriceEur.Text.Trim(), out var price) || price < 0)
            {
                MessageBox.Show("Моля въведи валидна цена в EUR (число).");
                txtPriceEur.Focus();
                return;
            }

            // Create model from UI values
            var item = new MenuItem
            {
                Id = _editId ?? 0,
                ProductName = name,
                CategoryId = Convert.ToInt64(cmbCategory.SelectedValue),
                Description = txtDescription.Text.Trim(),
                WeightGrams = grams,
                PriceEur = price,
                ImagePath = _imagePath ?? ""
            };

            // Persist new or updated item
            if (_editId == null)
                _repo.Create(item);
            else
                _repo.Update(item);

            // Notify host that save completed
            Saved?.Invoke(this, EventArgs.Empty);
        }

    }
}
