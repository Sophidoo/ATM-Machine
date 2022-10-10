using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public class AtmRequests
    {
        AccountDetails _accountDetails = new AccountDetails();   
        private int action;
        public void setAction(int action)
        {
            this.action = action;
        }
        public int getAction()
        {
            return action;
        }

        public void CreateAccount()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("|                 ATM MACHINE                  |");
            Console.WriteLine("================================================");

            Console.WriteLine("\n\nPlease Input your account name:");
            _accountDetails.setAccountName(Console.ReadLine());

            Console.WriteLine("\nPlease create your pin");
            _accountDetails.setAccountPin(Convert.ToInt32(Console.ReadLine()));
        }
        public void requests()
        {
            Console.WriteLine("\n==============================================================");
            Console.WriteLine("|                      WELCOME {0}                    |", _accountDetails.getAccountName());
            Console.WriteLine("==============================================================");
            Console.WriteLine("\n>>>What action do you want to perform?");
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Transfer Money");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Change Pin \n");
            Console.Write(">> ");
            setAction(Convert.ToInt32(Console.ReadLine()));

            AtmResponses();


        }


        public void AtmResponses()
        {
            if (getAction() == 1)
            {
                DepositMoney deposit = new DepositMoney();
                deposit.Transaction(_accountDetails);
            }
            else if (getAction() == 2)
            {
                WithdrawMoney withdraw = new WithdrawMoney();
                withdraw.Transaction(_accountDetails);
            }
            else if(getAction() == 3)
            {
                TransferMoney transfer = new TransferMoney();
                transfer.Transaction(_accountDetails);
            }
            else if(getAction() == 4)
            {
                viewAccount view = new viewAccount();
                view.Transaction(_accountDetails);
            }
            else if(getAction() == 5)
            {
                ChangingPin change = new ChangingPin();
                change.Transaction(_accountDetails);
            }


            if (_accountDetails.getIsPinCorrect())
            {
                Console.WriteLine("\n\n>>>> Do you want to perform another transaction, if yes write y, if no write n");
                Console.Write(">>>");
                char answer = Convert.ToChar(Console.ReadLine());

                if(answer == 'y')
                {
                    _accountDetails.validPin(_accountDetails.getAccountPin());

                    if(_accountDetails.getIsPinCorrect())
                    {
                        requests();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine(">>Please take your card");
                }
            }
            

        }

    }
}
