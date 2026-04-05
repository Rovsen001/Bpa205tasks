namespace Librarysystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            BookCode bookcode1=new BookCode("A",5);
            BookCode bookcode2 =new BookCode("B",9);
            Book book1=new Book("Title1","Author1",bookcode1, DateTime.Now.AddDays(-2));
            Book book2=new Book("Title2", "Author2", bookcode2, DateTime.Now.AddDays(-15));
            LibraryBook librarybook1=new LibraryBook(book1);
            LibraryBook librarybook2=new LibraryBook(book2);
            librarybook1.Borrow();
            librarybook1.Return();
            librarybook2.Borrow();
            librarybook2.Return();
            Console.WriteLine($"New : {book1.CreatedDate.IsNew()}\nNew : {book2.CreatedDate.IsNew()}");
          
        }
    }
}
