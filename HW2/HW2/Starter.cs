using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    static class Starter
    {
        public static void Run()
        {

            User user = new User();
            addProducts();
            EventListener.Run(user);
        }
        private static void addProducts()
        {
            Products.GetProducts().AddProduct(new Product("Яблоко",1.43m));
            Products.GetProducts().AddProduct(new Product("Слива", 2.23m));
            Products.GetProducts().AddProduct(new Product("Груша", 3.54m));
            Products.GetProducts().AddProduct(new Product("Арбуз", 12m));
            Products.GetProducts().AddProduct(new Product("Киви", 3.5m));
            Products.GetProducts().AddProduct(new Product("Алыча", 0.35m));
            Products.GetProducts().AddProduct(new Product("Дыня", 10m));
            Products.GetProducts().AddProduct(new Product("Картошка", 0.98m));
            Products.GetProducts().AddProduct(new Product("Огурец", 1.1m));
            Products.GetProducts().AddProduct(new Product("Помидор", 1.45m));
            Products.GetProducts().AddProduct(new Product("Морковь", 1.23m));
        } 
    }
}
