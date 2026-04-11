using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{

    
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Price={Price}";
        }
    }
}
