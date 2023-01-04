using System.Windows.Controls;
using TestApp.Model;
using TestApp.ViewModel;

namespace TestApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderCRUD.xaml
    /// </summary>
    public partial class OrderCRUD : UserControl
    {

        private OrderCRUD_VM _vm;

        public OrderCRUD(Order order=null)
        {
            InitializeComponent();
            _vm = new OrderCRUD_VM(order);
            this.DataContext = _vm;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void DeleteProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _vm.DeleteProduct();
        }

        //вызывает событие на изменение редактирование ячейки
     
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            _vm.OnPropertyChanged(nameof(_vm.Price));
        }

        private void AddProduct_Click ( object sender, System.Windows.RoutedEventArgs e ) {
            var sw = new SelectProductWindow ( );
            sw.ShowDialog();
            if ( sw.SelectProduct != null ) {
                _vm.AddProduct ( sw.SelectProduct );
            }
        }
    }
}
