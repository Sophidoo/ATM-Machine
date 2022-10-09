using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public class TransactionAmount
    {
        private double amount;
        public void setAmount(double amount)
        {
            this.amount = amount;
        }
        public double getAmount()
        {
            return amount;
        }
    }
}
