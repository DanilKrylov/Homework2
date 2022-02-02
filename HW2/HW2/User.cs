using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class User
    {
        public ShopCart UserShopCart = new ShopCart();

        public List<Order> Orders = new List<Order>();

        public User()
        {
            
        }

        public void AddOrder(ShopCart shopCart)
        {
            Orders.Add(new Order(shopCart));
            UserShopCart = new ShopCart();
        }

        public Order GetOrderOrNull(int ID)
        {
            Order order = null;

            foreach (Order elem in Orders)
            {
                if(elem.ID == ID)
                {
                    order = elem;
                    break;
                }
            }
            return order;
        }
    }
}