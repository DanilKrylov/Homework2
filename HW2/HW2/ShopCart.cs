using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class ShopCart
    {
        public Dictionary<Product, int> Products { get; private set; } = new Dictionary<Product, int>();

        public bool TryAddProduct(Product product, int count)
        {
            int lastCount;
            if (count >= 100)
            {
                return false;
            }
            if(Products.TryGetValue(product, out lastCount))
            {
                if (count + lastCount >= 100)
                {
                    return false;
                }
                Products[product] = lastCount + count;
                return true;
            }

            Products[product] = count;
            return true;
        }

        public void Clear()
        {
            Products = new Dictionary<Product, int>();
        }

        public decimal GetFullPrice()
        {
            decimal sum = 0m;
            foreach(KeyValuePair<Product,int> elem in Products)
            {
                sum += elem.Key.Price * elem.Value;
            }
            return sum;
        }
    }
}
