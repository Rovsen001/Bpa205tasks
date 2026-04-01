using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    internal class Bank
    {
       
        private const string _bankName = "CodeBank";
        private static int _totalAccounts=0;
        private static readonly DateTime _createdDate;
        public static int TotalAccounts { get; set; } 
         static Bank()
        {
            _createdDate = DateTime.Now;

        }
  
        public static void ShowBankInfo()
        {
            Console.WriteLine($"Bank name={_bankName}\nTotal account={TotalAccounts}\nCreate date={_createdDate}");
        }
     
    }
}
