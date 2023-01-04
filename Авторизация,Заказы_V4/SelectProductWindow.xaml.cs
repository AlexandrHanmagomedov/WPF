using System.Collections.Generic;
using System.Windows;
using TestApp.Model;

namespace TestApp {
    /// <summary>
    /// Логика взаимодействия для SelectProductWindow.xaml
    /// </summary>
    public partial class SelectProductWindow : Window {
        public SelectProductWindow ( ) {
            InitializeComponent ( );
            _nodes=new List<INode>(UsersDB.Context.Folders);
            ProductsTree.ItemsSource= _nodes;
        }
        private List<INode> _nodes;

        private Product _selectProduct;
        public Product SelectProduct { get { return _selectProduct; } }
        //проверка выбора продукт ноде чтобы выбрать продукт
        private void Select_Click ( object sender, RoutedEventArgs e ) {
            ProductNode product = ProductsTree.SelectedItem as ProductNode;
            if ( product != null ) {
            _selectProduct=product.Product;
            }
            this.Close();
        }
    }
}
