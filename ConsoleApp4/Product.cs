using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace ConsoleApp4
{
    internal class Product
    {
        public string name = "";
        public int price = 0;
        public int stock = 0;
        public string Name { get { return name; } set { if (name == "" && name == null) Console.WriteLine("Name cannot be empty!"); else name = value; } }
        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0) Console.WriteLine("Price cannot be negative!");
                else price = value;
            }
        }
        public int Stock
        {
            get { return stock; }
            set
            {
                if (value < 0) Console.WriteLine("Stock cannot be negative!");
                else stock = value;
            }
        }
        public Product(string name, int price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Console.WriteLine("Product CTOR worked");

        }
    }
}
