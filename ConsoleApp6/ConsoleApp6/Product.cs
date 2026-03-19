using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    internal class Product
    {
        public string Name;
        public double Price;
        public string GetName() {  return Name; }
        public double GetPrice() { return Price; }
        public string SetName(string name) {return Name = name; }
        public double SetPrice(double price) { return Price=price; }

        public void ShowInfo()
        {
            
            Console.WriteLine($"Name: {Name}, Price: {Price}");
         
        }
    }
}
