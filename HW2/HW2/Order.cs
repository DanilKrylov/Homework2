using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Order
    {
        private static int lastID = 0;
        public Dictionary<Product, int> Products { get; private set; } = new Dictionary<Product, int>();

        public int ID { get; }

        public decimal toPay { get; }

        public bool isPayed { get; private set; } = false ;

        public void Pay()
        {
            isPayed = true;
        }
        public Order(ShopCart shopCart)
        {
            Products = shopCart.Products;
            ID = lastID + 1;
            lastID++;
            toPay = shopCart.GetFullPrice();
        }
    }
}
