using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Products
    {
        private static Products products;

        private Products(){}

        public static Products GetProducts()
        {
            if (products == null)
            {
                products = new Products();
            }

            return products;
        }

        public List<Product> Prod = new List<Product>();

        public void AddProduct(Product product)
        {
            Prod.Add(product);
        }
    }
}
