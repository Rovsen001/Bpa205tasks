namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Bank bank= new Bank();
            Account account1= new Account("Name1",865.9);
            Account account2= new Account("Name2",700);
            Account account3 = new Account("Name3",927.4);
            Bank.ShowBankInfo();

        }
    }
}
