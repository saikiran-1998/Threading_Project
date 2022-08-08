using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocksAndMonitor
{
    internal class Account
    {
        public int balance { get; set; }
        Object objLock = new Object();
        Random random = new Random();
        public Account(int initialBalance)
        {
            balance = initialBalance;
        }
        private int WithdrawAmount(int amount)
        {
            if (balance < 0)
            {
                throw new Exception("There is no balance");
            }
            Monitor.Enter(objLock);
            try
            {
                if (amount < balance)
                {
                    Console.WriteLine("withdrawl of {0} is successful", amount);
                    balance = balance - amount;
                    return balance;
                }
            }
            finally
            {
                Monitor.Exit(objLock);
            }

            return 0;
        }
        public void withdrawRandomly()
        {
            for (int i = 0; i < 20; i++)
            {
                balance = WithdrawAmount(random.Next(3000, 5000));
                if (balance > 0)
                {
                    Console.WriteLine("balance is {0}", balance);
                } 
            }
        }
    }
}
