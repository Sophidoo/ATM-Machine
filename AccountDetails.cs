using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public class AccountDetails
    {
        private string? accountName;
        private int pin;
        private double accountBalance;
        
        public void setAccountName(string? accountName)
        {
            this.accountName = accountName;
        }
        public string? getAccountName()
        {
            return accountName;
        }


        public void setAccountPin(int pin)
        {
            this.pin = pin;
        }
        public int getAccountPin()
        {
            return pin;
        }

        public void setAccountBalance(double accountBalance)
        {
            this.accountBalance = accountBalance;
        }
        public double getAccountBalance()
        {
            return accountBalance;
        }
        
    }
}
