using System.Windows.Forms.VisualStyles;
using VSP__559ir_MyProject.Data;

namespace VSP__559ir_MyProject.Views
{
    public partial class MenuView : UserControl
    {
        public event EventHandler? BackRequested;
        public event EventHandler? CreateRequested;
        public event EventHandler<long>? EditRequested;

        private readonly MenuRepository _repo = new MenuRepository();

        public MenuView()
        {
            InitializeComponent();
            InitializeGrid();
            LoadFromDb();

            gridMenu.CellPainting += gridMenu_CellPainting;
            gridMenu.CellMouseClick += gridMenu_CellMouseClick;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }

        private void newProductButton_Click(object sender, EventArgs e)
        {
            CreateRequested?.Invoke(this, EventArgs.Empty);
        }

        private void InitializeGrid()
        {
            gridMenu.AllowUserToAddRows = false;
            gridMenu.AllowUserToDeleteRows = false;
            gridMenu.ReadOnly = true;
            gridMenu.MultiSelect = false;
            gridMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Reduce edge cases for clicks/painting
            gridMenu.RowHeadersVisible = false;

            gridMenu.Columns.Clear();

            gridMenu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                HeaderText = "id",
                FillWeight = 10
            });

            gridMenu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "product_name",
                HeaderText = "Продукт",
                FillWeight = 45
            });

            gridMenu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "product_category",
                HeaderText = "Категория",
                FillWeight = 25
            });

            var imgCol = new DataGridViewImageColumn
            {
                Name = "image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                FillWeight = 15
            };
            gridMenu.Columns.Add(imgCol);

            gridMenu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "actions",
                HeaderText = "Действия",
                FillWeight = 20
            });
        }

        private void LoadFromDb()
        {
            gridMenu.Rows.Clear();
            var items = _repo.GetAll();

            foreach (var item in items)
            {
                gridMenu.Rows.Add(
                    item.Id,
                    item.ProductName,
                    item.CategoryName,
                    LoadThumb(item.ImagePath),
                    ""
                );
            }
        }

        private static Image? LoadThumb(string path, int maxW = 64, int maxH = 64)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                    return null;

                using var bmpTemp = new Bitmap(path);
                var thumb = bmpTemp.GetThumbnailImage(maxW, maxH, () => false, IntPtr.Zero);
                return new Bitmap(thumb);
            }
            catch
            {
                return null;
            }
        }

        private static Rectangle GetEditButtonRect(Rectangle cellRect)
        {
            var buttonWidth = (cellRect.Width - 10) / 2;
            var buttonHeight = cellRect.Height - 8;

            return new Rectangle(
                cellRect.Left + 4,
                cellRect.Top + 4,
                buttonWidth,
                buttonHeight
            );
        }

        private static Rectangle GetDeleteButtonRect(Rectangle cellRect)
        {
            var editRect = GetEditButtonRect(cellRect);

            return new Rectangle(
                editRect.Right + 4,
                cellRect.Top + 4,
                editRect.Width,
                editRect.Height
            );
        }

        private void gridMenu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            if (e.ColumnIndex >= gridMenu.Columns.Count) return;

            if (gridMenu.Columns[e.ColumnIndex].Name != "actions")
                return;

            e.PaintBackground(e.ClipBounds, true);

            var cellRect = e.CellBounds;

            var editRect = GetEditButtonRect(cellRect);
            var deleteRect = GetDeleteButtonRect(cellRect);

            ButtonRenderer.DrawButton(
                e.Graphics,
                editRect,
                "Edit",
                gridMenu.Font,
                false,
                PushButtonState.Default
            );

            ButtonRenderer.DrawButton(
                e.Graphics,
                deleteRect,
                "Delete",
                gridMenu.Font,
                false,
                PushButtonState.Default
            );

            e.Handled = true;
        }

        private void gridMenu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            if (e.ColumnIndex >= gridMenu.Columns.Count) return;

            if (gridMenu.Columns[e.ColumnIndex].Name != "actions")
                return;

            var cellRect = gridMenu.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            // Mouse coordinates are relative to the cell, convert to absolute grid coordinates
            var clickPoint = new Point(cellRect.Left + e.X, cellRect.Top + e.Y);

            var editRect = GetEditButtonRect(cellRect);
            var deleteRect = GetDeleteButtonRect(cellRect);

            var idObj = gridMenu.Rows[e.RowIndex].Cells["id"].Value;
            if (idObj == null) return;

            var id = Convert.ToInt64(idObj);

            if (editRect.Contains(clickPoint))
            {
                EditRequested?.Invoke(this, id);
                return;
            }

            if (deleteRect.Contains(clickPoint))
            {
                var name = gridMenu.Rows[e.RowIndex].Cells["product_name"].Value?.ToString() ?? "";

                var confirm = MessageBox.Show(
                    $"Сигурен ли си, че искаш да изтриеш '{name}'?",
                    "Потвърждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    _repo.Delete(id);
                    LoadFromDb();
                }
            }
        }
    }
}
