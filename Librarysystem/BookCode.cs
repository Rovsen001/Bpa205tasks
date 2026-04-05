using System;
using System.Collections.Generic;
using System.Text;

namespace Librarysystem
{
    internal struct BookCode
    {
        public string Section { get; set;  }
        public int Number {  get; set; }
        public BookCode(string section,int number)
        {
            Section=section;
            Number=number;
        }
        public override string ToString()
        {
            return $"{Section}-{Number}";
        }
    }
}
