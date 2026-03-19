using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    internal class Book:Product
    {
        public string Author;
        public string SetAuthor(string author)
        {
            return Author=author;
        }
        public string GetAuthor() { return Author; }
        public void ShowBookInfo()
        {
            ShowInfo();
            Console.WriteLine($"Author: {Author}");

        }
    }
}
