using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class Laptop : Product
    {
        public int ram = 0;
        public string processor = "";
        public int RAM { get { return ram; } set { ram = value; } }
        public string Processor { get { return processor; } set { processor = value; } }
        public Laptop(string name, int price, int stock, int ram, string processor) : base(name, price, stock)
        {
            Processor = processor;
            RAM = ram;
            Console.WriteLine("Laptop CTOR worked");

        }
    }
}
