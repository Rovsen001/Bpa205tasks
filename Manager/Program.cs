namespace Manager;
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Manager<Product, int> productManager = new Manager<Product, int>();

        
        productManager.Add(new Product { Id = 1, Name = "Telefon", Price = 1200 });
        productManager.Add(new Product { Id = 2, Name = "Noutbuk", Price = 2500 });
        productManager.Add(new Product { Id = 1, Name = "Planset", Price = 800 }); 

       
        productManager.Remove(2);
        productManager.Remove(5); 

        
        productManager.Update(new Product { Id = 1, Name = "Smartfon", Price = 1100 });
        productManager.Update(new Product { Id = 3, Name = "Monitor", Price = 500 });

        
        var product = productManager.GetById(1);
        if (product != null)
            Console.WriteLine(product);

        
        var allProducts = productManager.GetAll();
        foreach (var p in allProducts)
        {
            Console.WriteLine(p);
        }
    }
}
