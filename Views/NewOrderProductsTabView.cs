using SDA_559ir.Data;
using SDA_559ir.Models;
using SDA_559ir.Views.Controls;

namespace SDA_559ir.Views
{
    public partial class NewOrderProductsTabView : UserControl
    {
        private readonly NewOrderDraft _draft;
        private readonly MenuRepository _menuRepo = new MenuRepository();

        private long? _activeCategoryId;

        public event EventHandler? NextRequested;

        public NewOrderProductsTabView(NewOrderDraft draft)
        {
            InitializeComponent();
            _draft = draft;

            Load += NewOrderProductsTabView_Load;

            // Optional Next buttons by name
            WireNextButtonsIfExist();

            // Keep cards width aligned with the scroll container width
            flpProducts.SizeChanged += (_, __) => ResizeCards();
        }

        private void WireNextButtonsIfExist()
        {
            var top = FindButton("btnNextTop");
            var bottom = FindButton("btnNextBottom");

            if (top != null) top.Click += NextClick;
            if (bottom != null) bottom.Click += NextClick;
        }

        private Button? FindButton(string name)
        {
            var found = Controls.Find(name, true);
            if (found.Length == 0) return null;
            return found[0] as Button;
        }

        private void NewOrderProductsTabView_Load(object? sender, EventArgs e)
        {
            flpCategories.WrapContents = false;
            flpCategories.AutoScroll = true;

            flpProducts.FlowDirection = FlowDirection.TopDown;
            flpProducts.WrapContents = false;
            flpProducts.AutoScroll = true;

            BuildCategoryButtons();
            LoadProducts();
        }

        private void NextClick(object? sender, EventArgs e)
        {
            if (_draft.ItemsByMenuItemId.Count == 0)
            {
                MessageBox.Show("Select at least 1 product.");
                return;
            }

            NextRequested?.Invoke(this, EventArgs.Empty);
        }

        private void BuildCategoryButtons()
        {
            flpCategories.Controls.Clear();

            var categories = _menuRepo.GetCategories();

            var allBtn = CreateCategoryButton("All", null);
            allBtn.SetToggled(true);
            flpCategories.Controls.Add(allBtn);

            foreach (var c in categories)
            {
                flpCategories.Controls.Add(CreateCategoryButton(c.Name, c.Id));
            }
        }

        private CategoryToggleButton CreateCategoryButton(string text, long? categoryId)
        {
            var btn = new CategoryToggleButton
            {
                Text = text,
                Tag = categoryId,
                Margin = new Padding(6, 6, 6, 6)
            };

            btn.Click += (_, __) =>
            {
                foreach (var control in flpCategories.Controls)
                {
                    if (control is CategoryToggleButton b) b.SetToggled(false);
                }

                btn.SetToggled(true);
                _activeCategoryId = categoryId;
                LoadProducts();
            };

            return btn;
        }

        private void LoadProducts()
        {
            flpProducts.SuspendLayout();
            flpProducts.Controls.Clear();

            var items = _menuRepo.GetMenuItems(_activeCategoryId);

            foreach (var item in items)
            {
                var card = new MenuItemCardView
                {
                    Width = GetCardWidth(),
                    Margin = new Padding(10, 8, 10, 8)
                };

                var currentQty = _draft.GetQty(item.Id);
                card.Bind(item, currentQty);

                card.QtyChanged += (_, qty) =>
                {
                    _draft.SetQty(item.Id, qty);
                };

                card.DeleteRequested += (_, __) =>
                {
                    _draft.SetQty(item.Id, 0);
                    card.Bind(item, 0);
                };

                flpProducts.Controls.Add(card);
            }

            flpProducts.ResumeLayout();
        }

        private void ResizeCards()
        {
            var width = GetCardWidth();

            foreach (Control c in flpProducts.Controls)
            {
                if (c is MenuItemCardView card)
                    card.Width = width;
            }
        }

        private int GetCardWidth()
        {
            var w = flpProducts.ClientSize.Width - 30;
            return w < 200 ? 200 : w;
        }
    }
}
