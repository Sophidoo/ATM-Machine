using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public interface ITransactions
    {
        public abstract void Transaction(AccountDetails _accountDetails, AccountPinValidation pinValidation);
    }

    public class DepositMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();

        public void Transaction(AccountDetails _accountDetails, AccountPinValidation pinValidation)
        {
            Console.WriteLine("\n>>> How much do you want to deposit:");
            Console.Write(">>>");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() + _amount.getAmount());

            Console.Write("\n>>>TRANSACTION SUCCESSFULL");
            pinValidation.setIsPinCorrect(true);
        }

    }

    public class WithdrawMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();

        public void Transaction(AccountDetails _accountDetails, AccountPinValidation pinValidation)
        {
            Console.WriteLine("\n>>>How much do you want to withdraw:");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            if(_amount.getAmount() >= _accountDetails.getAccountBalance() || _amount.getAmount() <= 0)
            {
                Console.WriteLine("\n>>>Insufficient Funds, Please deposit money into your account.");
                pinValidation.setIsPinCorrect(true);
            }
            else
            {
                pinValidation.validPin(_accountDetails.getAccountPin());

                if (pinValidation.getIsPinCorrect())
                {
                    _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() - _amount.getAmount());
                    Console.Write("\n>>>Successful! Please Take Your Money");
                }
                else
                {
                    return;
                }
            }
        }


    }

    public class TransferMoney : ITransactions
    {
        TransactionAmount _amount = new TransactionAmount();

        private int recepientNumber;
        private string? recepientBank;
        public void Transaction(AccountDetails _accountDetails, AccountPinValidation pinValidation)
        {

            Console.WriteLine("\n>>>Please enter the Receiver's account Number");
            Console.Write(">>>");
            recepientNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n>>>Please enter Receiver's Bank Name");
            Console.Write(">>>");
            recepientBank = Console.ReadLine();

            Console.WriteLine("\n>>>Please Enter the amount you are sending");
            Console.Write(">>>");
            _amount.setAmount(Convert.ToDouble(Console.ReadLine()));

            if (_amount.getAmount() >= _accountDetails.getAccountBalance() || _amount.getAmount() <= 0)
            {
                Console.WriteLine("\n>>>Insufficient Funds, Please deposit money into your account");
                pinValidation.setIsPinCorrect(true);
            }
            else if(recepientNumber.ToString().Length <= 8)
            {
                Console.WriteLine("\n>>>Invalid Account Number Hint: a valid account number should be up to 10digits");
                pinValidation.setIsPinCorrect(true);
            }
            else
            {
                pinValidation.validPin(_accountDetails.getAccountPin());

                if (pinValidation.getIsPinCorrect())
                {
                    _accountDetails.setAccountBalance(_accountDetails.getAccountBalance() - _amount.getAmount());
                    Console.WriteLine("\n>>>Sent Sucessfully");

                    Console.WriteLine("\n=====================================================");
                    Console.WriteLine("|                   YOUR RECEIPT                    |");
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("\n>>Receivers Account Number: {0}", recepientNumber);
                    Console.WriteLine(">>Receivers' Bank:          {0}", recepientBank);
                    Console.WriteLine(">>Amount Sent:              {0}", _amount.getAmount());
                    Console.WriteLine(">>Transaction Status:       Successfull");

                    pinValidation.setIsPinCorrect(true);
                }
                else
                {
                    return;
                }
            }

            
        }


    }


    public class ChangingPin : ITransactions
    {
        

        public void Transaction(AccountDetails _accountDetails, AccountPinValidation pinValidation)
        {
            Console.WriteLine("\nPlease Enter your new pin:");
            int pin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPlease Enter confirm your new pin:");
            int Confirmpin = Convert.ToInt32(Console.ReadLine());

            if(pin != Confirmpin)
            {
                Console.WriteLine("\nPin does not match");
                pinValidation.setIsPinCorrect(true);
            }
            else
            {
                _accountDetails.setAccountPin(Confirmpin);
                Console.WriteLine("\n Pin Sucessfully Changed");
                pinValidation.setIsPinCorrect(true);
            }
        }

    }

    public class viewAccount : ITransactions
    {
        public void Transaction(AccountDetails _accountDetails, AccountPinValidation pinValidation)
        {
            Console.WriteLine("\n\n=======================================================");
            Console.WriteLine("|                 YOUR ACCOUNT BALANCE                |");
            Console.WriteLine("=======================================================\n");
            Console.WriteLine(">>Account Name:     {0}", _accountDetails.getAccountName());
            Console.WriteLine(">>Your Balance is:  N{0}", _accountDetails.getAccountBalance());
            pinValidation.setIsPinCorrect(true);
        }
    }
    
    
    
}
