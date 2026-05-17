using VSP__559ir_MyProject.Data;
using VSP__559ir_MyProject.Models;

namespace VSP__559ir_MyProject.Views
{
    public partial class NewOrderView : UserControl
    {
        private readonly NewOrderDraft _draft = new NewOrderDraft();

        private NewOrderProductsTabView? _tabProducts;
        private NewOrderDeliveryTabView? _tabDelivery;
        private NewOrderAssignmentTabView? _tabAssignment;
        private NewOrderPreviewTabView? _tabPreview;

        private readonly long? _editingOrderId;

        private readonly OrderRepository _orderRepo = new OrderRepository();

        public event EventHandler? BackRequested;

        public NewOrderView(long? orderId = null)
        {
            InitializeComponent();

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.Selecting += tabControl1_Selecting;

            _editingOrderId = orderId;

            Load += NewOrderView_Load;
            btnBack.Click += btnBack_Click;
        }

        private void NewOrderView_Load(object? sender, EventArgs e)
        {
            // 1) If editing, load draft from DB BEFORE creating tabs
            if (_editingOrderId.HasValue)
            {
                var loaded = _orderRepo.GetOrderDraft(_editingOrderId.Value);
                if (loaded == null)
                {
                    MessageBox.Show("Поръчката не е намерена.");
                    BackRequested?.Invoke(this, EventArgs.Empty);
                    return;
                }

                CopyDraft(loaded, _draft);
            }
            else
            {
                // New order
                _draft.OrderId = null;
            }

            // 2) Create tabs after draft is ready
            _tabProducts = new NewOrderProductsTabView(_draft);
            _tabDelivery = new NewOrderDeliveryTabView(_draft);
            _tabAssignment = new NewOrderAssignmentTabView(_draft);
            _tabPreview = new NewOrderPreviewTabView();

            // 3) Next navigation (still works, but user can also click tabs)
            _tabProducts.NextRequested += (_, __) => tabControl1.SelectedTab = tabPageDelivery;
            _tabDelivery.NextRequested += (_, __) => tabControl1.SelectedTab = tabPageAssignment;

            // 4) Save from Assignment: create first time, then update afterwards
            _tabAssignment.OrderSaved += (_, orderId) =>
            {
                tabPagePreview.Enabled = true;
                tabControl1.Invalidate();

                _tabPreview.SetOrderId(orderId);
                _tabPreview.RefreshPreview();

                tabControl1.SelectedTab = tabPagePreview;
            };

            // 5) Mount views
            Mount(tabPageProducts, _tabProducts);
            Mount(tabPageDelivery, _tabDelivery);
            Mount(tabPageAssignment, _tabAssignment);
            Mount(tabPagePreview, _tabPreview);

            // 6) Preview availability
            tabPagePreview.Enabled = _draft.OrderId.HasValue;
            tabControl1.Invalidate();

            // 7) Open Preview first only when editing, otherwise start from Products
            if (_draft.OrderId.HasValue)
            {
                _tabPreview.SetOrderId(_draft.OrderId.Value);
                _tabPreview.RefreshPreview();
                tabControl1.SelectedTab = tabPagePreview;
            }
            else
            {
                tabControl1.SelectedTab = tabPageProducts;
            }
        }

        private static void CopyDraft(NewOrderDraft src, NewOrderDraft dst)
        {
            dst.OrderId = src.OrderId;
            dst.CustomerName = src.CustomerName;
            dst.CustomerPhone = src.CustomerPhone;
            dst.DeliveryAddress = src.DeliveryAddress;
            dst.CourierId = src.CourierId;
            dst.DeliverAt = src.DeliverAt;
            dst.Status = src.Status;

            dst.ItemsByMenuItemId.Clear();
            foreach (var kv in src.ItemsByMenuItemId)
                dst.ItemsByMenuItemId[kv.Key] = kv.Value;
        }

        private static void Mount(TabPage page, UserControl view)
        {
            page.Controls.Clear();
            view.Dock = DockStyle.Fill;
            page.Controls.Add(view);
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }

        private void tabControl1_DrawItem(object? sender, DrawItemEventArgs e)
        {
            var tab = tabControl1.TabPages[e.Index];
            var text = tab.Text;

            var isDisabled = !tab.Enabled;

            using var backBrush = new SolidBrush(tabControl1.BackColor);
            e.Graphics.FillRectangle(backBrush, e.Bounds);

            var textColor = isDisabled ? SystemColors.GrayText : SystemColors.ControlText;
            TextRenderer.DrawText(
                e.Graphics,
                text,
                tabControl1.Font,
                e.Bounds,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void tabControl1_Selecting(object? sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPagePreview && !tabPagePreview.Enabled)
            {
                e.Cancel = true;
            }
        }

    }
}
