﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Product
    {
        public string Name { get; }

        public decimal Price { get; }
        
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
