using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public interface ITransactions
    {
        public abstract void Transaction(AccountDetails _accountDetails);
    }

    public class DepositMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();

        public void Transaction(AccountDetails _accountDetails)
        {
            Console.WriteLine("\n>>> How much do you want to deposit:");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() + _amount.getAmount());

            Console.Write("\n>>>TRANSACTION SUCCESSFULL");
        }

    }

    public class WithdrawMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();

        public void Transaction(AccountDetails _accountDetails)
        {
            Console.WriteLine("\n>>>How much do you want to withdraw:");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            if(_amount.getAmount() >= _accountDetails.getAccountBalance())
            {
                Console.WriteLine("\n>>>Insufficient Funds");
            }
            else
            {
                Console.WriteLine("\n>>>Please input your pin {0}", _accountDetails.getAccountPin());
                int ConfirmPin = Convert.ToInt32(Console.ReadLine());

                if(ConfirmPin != _accountDetails.getAccountPin())
                {
                    Console.WriteLine(">>>Incorrect Pin");
                }
                else
                {
                    _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() - _amount.getAmount());
                    Console.Write("\n>>>Successful! Please Take Your Money");
                }
            }
        }


    }

    public class TransferMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();

        private int recepientNumber;
        private string? recepientBank;
        public void Transaction(AccountDetails _accountDetails)
        {

            Console.WriteLine("\n>>>Please enter the Receiver's account Number");
            recepientNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n>>>Please enter Receiver's Bank Name");
            recepientBank = Console.ReadLine();

            Console.WriteLine("\n>>>Please Enter the amount you are sending");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            Console.WriteLine("\n>>>Please Enter your pin");
            int pin = Convert.ToInt32(Console.ReadLine());

            if(_accountDetails.getAccountPin() == pin)
            {
                _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() - _amount.getAmount());
                Console.WriteLine("\n>>>Sent Sucessfully");

                Console.WriteLine("=====================================================");
                Console.WriteLine("\n|                  YOUR RECEIPT                   |");
                Console.WriteLine("=====================================================\n");
                Console.WriteLine(">>Receivers Account Number: {0}", recepientNumber);
                Console.WriteLine(">>Receivers' Bank:          {0}", recepientBank);
                Console.WriteLine(">>Amount Sent:              {0}", _amount.getAmount());
                Console.WriteLine(">>Transaction Status:       Successfull");
            }
            else
            {
                Console.WriteLine("\nInvalid Pin");
            }
        }

    }


    public class ChangingPin : ITransactions
    {
        

        public void Transaction(AccountDetails _accountDetails)
        {
            Console.WriteLine("\nPlease Enter your new pin:");
            int pin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPlease Enter confirm your new pin:");
            int Confirmpin = Convert.ToInt32(Console.ReadLine());

            if(pin != Confirmpin)
            {
                Console.WriteLine("\nPin does not match");
            }
            else
            {
                _accountDetails.setAccountPin(Confirmpin);
                Console.WriteLine("\n Pin Sucessfully Changed");
            }
        }

    }

    public class viewAccount : ITransactions
    {
        public void Transaction(AccountDetails _accountDetails)
        {
            Console.WriteLine("\n\n=======================================================");
            Console.WriteLine("|                 YOUR ACCOUNT BALANCE                |");
            Console.WriteLine("=======================================================\n");
            Console.WriteLine(">>Account Name:     {0}", _accountDetails.getAccountName());
            Console.WriteLine(">>Your Balance is:  N{0}", _accountDetails.getAccountBalance());
        }
    }
    
}
