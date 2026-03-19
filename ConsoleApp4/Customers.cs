using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class Customers : User
    {
        private int _balance;
        public int Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0) Console.WriteLine("Balance cannot be negative!");
                else _balance = value;
            }
        }


    }
}
