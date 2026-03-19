using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class Phone : Product
    {

        public string brand = "";
        public int storage = 0;
        public string Brand { get { return brand; } set { brand = value; } }
        public int Storage { get { return storage; } set { storage = value; } }
        public Phone(string name, int price, int stock, string brand, int storage) : base(name, price, stock)
        {
            Brand = brand;
            Storage = storage;
            Console.WriteLine("Phone CTOR worked");
        }
    }
}
