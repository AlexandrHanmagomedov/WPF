using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Model {
    public class ProductNode:INode {

        public ProductNode(Product p ) {
            Product = p;
        }
        public Product Product { get; private set; }
        public string Name { get { return Product.Name; } }
    }



}
