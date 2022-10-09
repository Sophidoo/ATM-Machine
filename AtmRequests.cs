using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public class AtmRequests
    {
        private int action;
        public void setAction(int action)
        {
            this.action = action;
        }
        public int getAction()
        {
            return action;
        }

        public void requests()
        {
            AccountDetails account = new AccountDetails();

            Console.WriteLine("\nWhat action do you want to perform?");
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Transfer Money");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Change Pin \n");
            setAction(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
