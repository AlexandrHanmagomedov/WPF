using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestApp.Pages;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
       
        public UserWindow()
        {
            InitializeComponent();
            this.DataContext = PageContext.CurrentPageContext;
            PageContext.CurrentPageContext.AddPage(new MainPage());
        }

        private void MainPageClick(object sender, RoutedEventArgs e)
        {
            PageContext.CurrentPageContext.ChangeRootPage(new MainPage());
        }

        private void OrdersPageClick(object sender, RoutedEventArgs e)
        {
            PageContext.CurrentPageContext.ChangeRootPage(new OrdersPage());
        }
    }
}
