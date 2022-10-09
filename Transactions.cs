using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public interface ITransactions
    {
        public abstract void Transaction();
        public abstract void TransDetails();
    }

    public class DepositMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();
        AccountDetails _accountDetails = new AccountDetails();
        AtmRequests requests = new AtmRequests();
            

        public void Transaction()
        {
            Console.WriteLine("\nHow much do you want to deposit:");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() + _amount.getAmount());
        }

        public void TransDetails()
        {
            Console.Write("\nYour New Account Balance is: {0}", _accountDetails.getAccountBalance());
            requests.requests();
        }
    }

    public class WithdrawMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();
        AccountDetails _accountDetails = new AccountDetails();
        AtmRequests requests = new AtmRequests();
        public void Transaction()
        {
            Console.WriteLine("\nHow much do you want to withdraw:");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            if(_amount.getAmount() >= _accountDetails.getAccountBalance())
            {
                Console.WriteLine("Insufficient Funds");
            }
            else
            {
                Console.WriteLine("Please input your pin");
                int pin = Convert.ToInt32(Console.ReadLine());

                if(_accountDetails.getAccountPin() != pin)
                {
                    Console.WriteLine("Incorrect Pin");
                }
                else
                {
                    _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() - _amount.getAmount());
                    Console.Write("\n Successful! Please Take Your Money");
                }
            }
        }

        public void TransDetails()
        {
            Console.Write("\n Successful! Please Take Your Money");
        }
    }

    public class TransferMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();
        AccountDetails _accountDetails = new AccountDetails();
        AtmRequests requests = new AtmRequests();

        private int recepientNumber;
        private string recepientBank;
        public void Transaction()
        {
            Console.WriteLine("\nPlease enter the Receiver's account Number");
            recepientNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPlease enter Receiver's Bank Name");
            recepientBank = Console.ReadLine();

            Console.WriteLine("\nPlease Enter the amount you are sending");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            Console.WriteLine("\nPlease Enter your pin");
            int pin = Convert.ToInt32(Console.ReadLine());

            if(_accountDetails.getAccountPin() == pin)
            {
                _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() - _amount.getAmount());
                Console.WriteLine("\nSent Sucessfully");

                Console.WriteLine("\nYour Receipt");
                Console.WriteLine("Receivers Account Number: {0}", recepientNumber);
                Console.WriteLine("Receivers' Bank: {0}", recepientBank);
                Console.WriteLine("Amount Sent: {0}", _amount.getAmount());
                Console.WriteLine("Transaction Status: Successfull");
            }
            else
            {
                Console.WriteLine("\nInvalid Pin");
            }
        }

        public void TransDetails()
        {
        }
    }


    public class ChangingPin : ITransactions
    {
        AccountDetails _accountDetails = new AccountDetails();

        public void Transaction()
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

        public void TransDetails()
        {
            throw new NotImplementedException();
        }
    }
}
