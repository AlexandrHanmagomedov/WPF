using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Model
{
    internal class UsersDB
    {
        private static UsersDB _context;
        public static UsersDB Context => _context?? (_context = new UsersDB());
        private UsersDB()
        {
            Orders = new ObservableCollection<Order>()
            {
                new Order() { Id=1, Client="Вася Пупкин", Date=new DateTime(2022,12,10),
                             Products=new ObservableCollection<OrderProduct>()
                             {
                                new OrderProduct(){Product=Products.First(x=>x.Id==1), Quantity=2},
                                new OrderProduct(){Product=Products.First(x=>x.Id==2), Quantity=1},
                                new OrderProduct(){Product=Products.First(x=>x.Id==3), Quantity=3},
                             }
                },
               new Order() { Id=2, Client="Иван Иванов", Date=new DateTime(2022,12,11),
                             Products=new ObservableCollection<OrderProduct>()
                             {
                                new OrderProduct(){Product=Products.First(x=>x.Id==3), Quantity=2},
                                new OrderProduct(){Product=Products.First(x=>x.Id==4), Quantity=1},
                                new OrderProduct(){Product=Products.First(x=>x.Id==5), Quantity=3},
                             }
                },
               new Order() { Id=3, Client="Пётр Петров", Date=new DateTime(2022,12,12),
                             Products=new ObservableCollection<OrderProduct>()
                             {
                                new OrderProduct(){Product=Products.First(x=>x.Id==4), Quantity=2},
                                new OrderProduct(){Product=Products.First(x=>x.Id==5), Quantity=1},
                                new OrderProduct(){Product=Products.First(x=>x.Id==3), Quantity=3},
                             }
                },
               new Order() { Id=4, Client="Александр Александров", Date=new DateTime(2022,12,10),
                             Products=new ObservableCollection<OrderProduct>()
                             {
                                new OrderProduct(){Product=Products.First(x=>x.Id==6), Quantity=2},
                                new OrderProduct(){Product=Products.First(x=>x.Id==2), Quantity=1},
                             }
                },
               new Order() { Id=5, Client="Вася Пупкин", Date=new DateTime(2022,12,10),
                             Products=new ObservableCollection<OrderProduct>()
                             {
                                new OrderProduct(){Product=Products.First(x=>x.Id==5), Quantity=10},
                             }
                },
            };
            //добавляются новые папки в список б и в продукцию
            Folders = new List<Folder> ( ) {
                new Folder(){Name="Конфеты",Nodes=new List<INode>()
                                           {
                                            new Folder() {Name="Подпапка",Nodes=new List<INode>()
                                                                            {
                                                                                new ProductNode(Products.First(x=>x.Id==1)) 
                                                                            } 
                                            },
                                            new ProductNode(Products.First(x=>x.Id==2))
                                            }
                },                
                new Folder() {Name="Торты",Nodes=new List<INode>()
                                            {
                                                new ProductNode(Products.First(x=>x.Id==3)) } 
                                            },
                new Folder() {Name="Прочее",Nodes=new List<INode>(Products.ToList().GetRange(3,3).Select(x=>new ProductNode(x))) }

            };
        }
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>()
        {
            new User("Анна","Anya123","12345"),
            new User("qwe","qwe123","123"),
            new User("Иван"," "," "),
            new User("Логин","Login","333"),
            new User("Пароль","Parol","qwerty"),
        };
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>()
        {
            new Product(){ Id=1, Name="Конфета шоколадная", Price=100M},
            new Product(){ Id=2, Name="Леденец \"Петушок\"", Price=50M},
            new Product(){ Id=3, Name="Вафельный торт", Price=300M},
            new Product(){ Id=4, Name="Безе цветное", Price=250M},
            new Product(){ Id=5, Name="Мармеладные мишки", Price=349M},
            new Product(){ Id=6, Name="Цукаты из ананаса", Price=299M},
        };

        public List<Folder> Folders { get; set; } 


        public ObservableCollection<Order> Orders { get; set; }
    }
}
