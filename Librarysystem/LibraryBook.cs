using System;
using System.Collections.Generic;
using System.Text;

namespace Librarysystem
{
    internal class LibraryBook : IBorrowable
    {
        private bool _isBorrowed;
        public Book Book { get; set; }
        public LibraryBook(Book book)
        {
            Book = book;
        }
        public void Borrow()
        {
            if (_isBorrowed) Console.WriteLine("Already borrowed");
            else
            {
                _isBorrowed = true;
                Console.WriteLine("You have borrowed the book");
            }

        }
        public void Return()
        {
            if (_isBorrowed == false) Console.WriteLine("Not borrowed");
            else
            {
                _isBorrowed = false;
                Console.WriteLine("You have returned the book");
            }
        }
    }
}
