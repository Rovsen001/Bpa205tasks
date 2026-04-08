using System;
using System.Collections.Generic;
using System.Text;

namespace Invantory
{
    internal class User
    {
        private string _username;
        private int _age;
        public string Username { get; set; }
        public int Age { get; set; }
        public User(string username,int age)
        {
            Username=username;
            Age=age;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
