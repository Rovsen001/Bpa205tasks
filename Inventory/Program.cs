namespace Invantory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Kitab", 12.50);
            Product product2 = new Product("Defter", 1.00);
            Product product3 = new Product("Qelem", 0.50);
            
            GenericInvantory<Product> product = new GenericInvantory<Product>() ;
            product.AddItem(product1);
            product.AddItem(product2);
            product.AddItem(product3);
            product.GetAllItems();
            Console.WriteLine(product.FindByIndex(0));
            product.RemoveItem(product1);
            product.GetAllItems();
            Console.WriteLine(product.FindByIndex(0));

          

            User user1=new User("User1",18);
            User user2 = new User("User2", 25);
            User user3 = new User("User3", 33);

            GenericInvantory<User> user = new GenericInvantory<User>();
            user.AddItem(user1);
            user.AddItem(user2);
            user.AddItem(user3);
            user.GetAllItems();
            Console.WriteLine(user.FindByIndex(0));
            user.RemoveItem(user1);
            user.GetAllItems();
            Console.WriteLine(user.FindByIndex(0));
        }
    }
}
