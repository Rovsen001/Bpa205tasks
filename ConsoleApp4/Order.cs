using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class Order : Product
    {
        public string customer = "";
        public string product = "";
        public int quantity = 0;
        public string Customer { get { return customer; } set { customer = value; } }
        public string Product { get { return product; } set { product = value; } }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity < 0) Console.WriteLine("Quantity cannot be negative!");
                else quantity = value;
            }
        }
        public int TotalPrice { get { return Price * Quantity; } }


        public Order(string name, int price, int stock, string customer, string product, int quantity) : base(name, price, stock)
        {
            Customer = customer;
            Product = product;
            Quantity = quantity;
            if (stock < quantity) Console.WriteLine("Not enough stock");
            else Stock = Stock - quantity;
            Console.WriteLine("Order CTOR worked");


        }
    }

}
