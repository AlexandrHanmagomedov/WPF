using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TestApp.Model;
using TestApp.ViewModel;

namespace TestApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : UserControl
    {
        private OrdersVM _vm;
        public OrdersPage()
        {
            InitializeComponent();
            _vm = new OrdersVM();
            this.DataContext = _vm;
        }
        //поиск по параметрам
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            _vm.UpdateListOrders();
        }
        //удаление записи
        private void DeleteOrders_Click(object sender, RoutedEventArgs e)
        {
            _vm.SelectedOrders = OrdersLV.SelectedItems.Cast<Order>().ToList();
            _vm.DeleteOrders();
        }

        //изменение первой выбранной записи из списка
        private void ModifyOrder_Click(object sender, RoutedEventArgs e)
        {
            _vm.SelectedOrders = OrdersLV.SelectedItems.Cast<Order>().ToList();
            //выбираем первую запись из селектед ордерс 
            Order order = _vm.SelectedOrders.FirstOrDefault();
            if (_vm.SelectedOrders != null)
            {
                var page = new OrderCRUD(order);//пердаем в страничку
                PageContext.CurrentPageContext.AddPage(page);
            }
           

        }
    }
}
