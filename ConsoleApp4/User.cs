using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class User
    {
        public string Name { get { return Name; } set { Name = value; } }
        public string Email
        {
            get { return Email; }
            set
            {
                if (value != "" && value != null) Email = value;
                else Console.WriteLine("Email cannot be empty");
            }
        }
    }
}
