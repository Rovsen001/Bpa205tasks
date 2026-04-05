using System;
using System.Collections.Generic;
using System.Text;

namespace Librarysystem
{
    internal record Book
    {
        public string Title { get; }
        public string Author { get; }
        public BookCode BookCode { get; }
        public DateTime CreatedDate { get; } 
        public Book(string title,string author,BookCode bookcode,DateTime createddate)
        {
            Title = title;
            Author = author;
            BookCode = bookcode;
            CreatedDate = createddate;
        }

    }
}
