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
        private bool isPinCorrect;
        private int invalidPinCounter;
        
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


        public void setIsPinCorrect(bool isPinCorrect)
        {
            this.isPinCorrect = isPinCorrect;
        }
        public bool getIsPinCorrect()
        {
            return isPinCorrect;
        }


        public void setInvalidPinCounter(int invalidPinCounter)
        {
            this.invalidPinCounter = invalidPinCounter;
        }
        public int getInvalidPinCounter()
        {
            return invalidPinCounter;
        }



        public void validPin(int pin)
        {
            int confirmPin = 0;
            setInvalidPinCounter(getInvalidPinCounter() + 1);
            if (getInvalidPinCounter() < 4)
            {
                Console.WriteLine("Please enter your pin {0}", getAccountPin());
                Console.Write(">>>");
                confirmPin  = Convert.ToInt32(Console.ReadLine());
            }

            if(confirmPin != pin && getInvalidPinCounter() < 4)
            {
                Console.Write("Incorrect,");
                validPin(pin);
            }else if(getInvalidPinCounter() > 3)
            {
                Console.WriteLine("\nYour account has been blocked, Please visit your bank");
                setIsPinCorrect(false);
                return;
            }
            else if(confirmPin == pin && getInvalidPinCounter() < 4)
            {
                setIsPinCorrect(true);
                setInvalidPinCounter(0);
                return;
            }
        }
        
    }
}
