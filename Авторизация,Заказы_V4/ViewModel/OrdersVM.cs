using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Model;

namespace TestApp.ViewModel
{
    internal class OrdersVM : NotifyClass
    {
        public OrdersVM()
        {
            //_searchText = "";
            Orders = UsersDB.Context.Orders.ToList();
        }
        public List<Order> Orders { get; set; }
        public List<Order> SelectedOrders { get; set; }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;  
                
                OnPropertyChanged();
            }
        }

        public void UpdateListOrders()
        {
            Orders = UsersDB.Context.Orders
                    .Where(x => _searchText == String.Empty || _searchText==null
                          ||(int.TryParse(_searchText, out int id) && x.Id == id)//поиск ИД
                          || (x.Client.ToLower().Contains(_searchText.ToLower()))//поиск клиента
                          || (DateTime.TryParse(_searchText,out DateTime date) && date==x.Date)//поиск даты
                          || (x.Products.FirstOrDefault(y=>y.Product.Name.ToLower().Contains(_searchText.ToLower()))!=null)) //поиск заказа
                    .ToList();
            OnPropertyChanged("Orders");
        }

        public void DeleteOrders()
        {
            
            foreach (var r in SelectedOrders)
            {
                UsersDB.Context.Orders.Remove(r);//выбираем из селектед,удаляем из ордерс
            }
            Orders = UsersDB.Context.Orders.ToList();//обновляем ордерс               
            SelectedOrders.Clear();//очистка селектед ордерс
            OnPropertyChanged(nameof(Orders));//изменился элемент ордерс , нужно пееррисовать
        }
    }
}
