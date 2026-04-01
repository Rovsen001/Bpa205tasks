using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    internal class Account
    {
        private string _ownerName;
        private double _balance;
        private readonly string _accountNumber;
        private static int _accountCounter=0;
        public string OwnerName { get; set; }
        public double Balance { get; set { if (value >= 0) _balance = value; else Console.WriteLine("Balance cannot be negative!"); } }
        public Account(string ownername,double balance)
        {
            _ownerName=ownername;
            _balance=balance;
            _accountNumber=Guid.NewGuid().ToString();
            _accountCounter++;
            Bank.TotalAccounts++;
        }
        public void Deposit(double amount)
        {
            if (amount >= 0) _balance = _balance + amount;
            else Console.WriteLine("Amount cannot be negative!");
        }
        public void Withdraw(double amount)
        {
            if (amount <= _balance) _balance = _balance - amount; else Console.WriteLine("Amount cannot be higher than balance!");
        }
    }
}
