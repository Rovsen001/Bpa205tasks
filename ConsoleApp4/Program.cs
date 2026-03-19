namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Customers customer = new Customers();
            Phone phon = new Phone("Samsung", 800, 10, "S25", 512);
            Laptop laptop = new Laptop("Asus", -3000, 5, 32, "i7-13450H");
            Order order = new Order("Buy", 3000, 60, "Elvin Məmmədov", "laptop", 2);
            Console.WriteLine(order.Stock);


        }
    }
}
