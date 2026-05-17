using System.Windows.Forms;
using VSP__559ir_MyProject.Data;

namespace VSP__559ir_MyProject
{
    public partial class InitialScreen : Form
    {
        private Views.HomeView? _homeView;
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public InitialScreen()
        {
            InitializeComponent();
            ShowHome();
        }

        private void ShowHome()
        {
            panelContent.Controls.Clear();

            _homeView = new Views.HomeView
            {
                Dock = DockStyle.Fill
            };

            // Navigation events
            _homeView.MenuRequested += (_, __) => ShowMenuAndRefresh();
            _homeView.CouriersRequested += (_, __) => OpenCouriers();

            // New Order navigation
            _homeView.NewOrderRequested += (_, __) => ShowNewOrder();
            _homeView.OrdersRequested += (_, __) => OpenOrders();



            panelContent.Controls.Add(_homeView);
        }

        private void ShowNewOrder()
        {
            var view = new Views.NewOrderView();

            view.BackRequested += (_, __) => ShowHome();

            ShowView(view);
        }

        private void OpenOrders()
        {
            var view = new VSP__559ir_MyProject.Views.OrdersView();

            view.BackRequested += (_, __) => ShowHome();

            view.EditRequested += (_, orderId) =>
            {
                var edit = new VSP__559ir_MyProject.Views.NewOrderView(orderId);
                edit.BackRequested += (_, __) => OpenOrders();
                ShowView(edit);
            };

            ShowView(view);
        }

        private void OpenCouriers()
        {
            var list = new Views.CouriersView();

            list.BackRequested += (_, __) => ShowHome();
            list.AddRequested += (_, __) => OpenCourierEdit(null, list);
            list.EditRequested += (_, id) => OpenCourierEdit(id, list);

            ShowView(list);
        }

        private void OpenCourierEdit(int? id, Views.CouriersView listView)
        {
            var edit = new Views.CourierEditView(id);

            edit.CancelRequested += (_, __) => ShowView(listView);
            edit.Saved += (_, __) =>
            {
                listView.RefreshGrid();
                ShowView(listView);
            };

            ShowView(edit);
        }

        private void ShowView(UserControl view)
        {
            panelContent.Controls.Clear();
            view.Dock = DockStyle.Fill;
            panelContent.Controls.Add(view);
        }

        private void ShowMenuAndRefresh()
        {
            panelContent.Controls.Clear();

            var menuView = new Views.MenuView
            {
                Dock = DockStyle.Fill
            };

            menuView.BackRequested += (_, __) => ShowHome();

            menuView.CreateRequested += (_, __) => ShowMenuCreate();
            menuView.EditRequested += (_, id) => ShowMenuEdit(id);

            panelContent.Controls.Add(menuView);
        }

        private void ShowMenuCreate()
        {
            panelContent.Controls.Clear();

            var editView = new Views.MenuItemEditView
            {
                Dock = DockStyle.Fill
            };

            editView.InitForCreate();
            editView.CancelRequested += (_, __) => ShowMenuAndRefresh();
            editView.Saved += (_, __) => ShowMenuAndRefresh();

            panelContent.Controls.Add(editView);
        }

        private void ShowMenuEdit(long id)
        {
            var item = _menuRepo.GetById(id);
            if (item == null)
            {
                MessageBox.Show("Продуктът не е намерен.");
                ShowMenuAndRefresh();
                return;
            }

            panelContent.Controls.Clear();

            var editView = new Views.MenuItemEditView
            {
                Dock = DockStyle.Fill
            };

            editView.InitForEdit(
                item.Id,
                item.ProductName,
                item.CategoryId,
                item.Description,
                item.WeightGrams,
                item.PriceEur,
                item.ImagePath
            );

            editView.CancelRequested += (_, __) => ShowMenuAndRefresh();
            editView.Saved += (_, __) => ShowMenuAndRefresh();

            panelContent.Controls.Add(editView);
        }
    }
}
