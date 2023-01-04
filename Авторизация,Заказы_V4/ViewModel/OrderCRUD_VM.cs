using System;
using System.Collections.ObjectModel;
using System.Linq;
using TestApp.Model;

namespace TestApp.ViewModel
{
    internal class OrderCRUD_VM : NotifyClass
    {
        public OrderCRUD_VM(Order order = null)
        {
            _currentOrder = new Order();

            //создаем новый обьект для текущего заказа , и если не равен нул то копируем значение заказа в куррент ордер
            if (order != null)           {
                _currentOrder.Products=new ObservableCollection<OrderProduct>(order.Products);
                _currentOrder.Client=order.Client;
                _currentOrder.Date = order.Date;
                _currentOrder.Id = order.Id;                
            }               
        }

        private Order _currentOrder;//текущий заказ

        public Order CurrentOrder
        {
            get
            {
                return _currentOrder;
                //get=>__currentOrder; или так
            }
            private set
            {//приватно чтобы нельзя было изменить заказ 
                _currentOrder = value;
            }
        }
        //свойство для привязки формы
        public int id
        {
            get { return _currentOrder.Id; }
            set
            {
                _currentOrder.Id = value;
                OnPropertyChanged();
            }
        }
        //свойство для привязки формы
        public string Client
        {
            get { return _currentOrder.Client; }
            set
            {
                _currentOrder.Client = value;
                OnPropertyChanged();
            }
        }
        //свойство для привязки формы
        public DateTime Date
        {
            get { return _currentOrder.Date; }
            set
            {
                _currentOrder.Date = value;
                OnPropertyChanged();
            }
        }
        //свойство для привязки формы
        public decimal Price => _currentOrder.Price;
        //свойство для привязки формы
        public ObservableCollection<OrderProduct> Products
        {
            get { return _currentOrder.Products; }

            set
            {
                _currentOrder.Products = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        //свойство для выделенной позиции 
        private OrderProduct _selectProduct;
        public OrderProduct SelectProduct
        {
            get => _selectProduct;
            set { _selectProduct = value;OnPropertyChanged(); }
        }

        //добавление нового продукта в заказ
        public void AddProduct(Product product)
        {
            var s = Products.FirstOrDefault ( x => x.Product.Id == product.Id );
            if (s!= null ) {
                s.Quantity++;
                return;
            }

            Products.Add (new OrderProduct ( ) { Product = product, Quantity = 1 } );
            OnPropertyChanged ( nameof ( Price ) );
        }
        //Удаление продукта из зазказа
        public void DeleteProduct()
        {
            Products.Remove(SelectProduct);
            OnPropertyChanged(nameof(Price));
        }



    }
}
