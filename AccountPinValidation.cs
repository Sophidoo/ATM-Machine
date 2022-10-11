using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public class AccountPinValidation
    {

        private bool isPinCorrect;
        private int invalidPinCounter;

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
                Console.WriteLine("\nPlease enter your pin");
                Console.Write(">>> ");
                confirmPin = Convert.ToInt32(Console.ReadLine());
            }

            if (confirmPin != pin && getInvalidPinCounter() < 4)
            {
                Console.Write("\n>>Incorrect,");
                validPin(pin);
            }
            else if (getInvalidPinCounter() > 3)
            {
                Console.WriteLine("\n>>Your account has been blocked, Please visit your bank");
                setIsPinCorrect(false);
                return;
            }
            else if (confirmPin == pin && getInvalidPinCounter() < 4)
            {
                setIsPinCorrect(true);
                setInvalidPinCounter(0);
                return;
            }
        }
    }
}
