using System;
using System.Collections.Generic;
using System.Text;

namespace Invantory
{
    internal class Product
    {
        private string _name;
        private double _price;
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string name,double price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"Name:{Name},Price:{Price}";
        }
    }
}
