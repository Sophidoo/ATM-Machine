using System.Security.Principal;

namespace ATM_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("|                 ATM MACHINE                  |");
            Console.WriteLine("================================================");

            AccountDetails accountDetails = new AccountDetails();

            Console.WriteLine("\n\nPlease Input your account name:");
            accountDetails.setAccountName(Console.ReadLine());

            Console.WriteLine("\nPlease create your pin");
            accountDetails.setAccountPin(Convert.ToInt32(Console.ReadLine()));


            AtmRequests requests = new AtmRequests();
            Console.WriteLine("\nWelcome {0}", accountDetails.getAccountName());
            requests.requests();


            if (requests.getAction() == 1)
            {
                DepositMoney deposit = new DepositMoney();
                deposit.Transaction();
                deposit.TransDetails();
            }
            else if(requests.getAction() == 2)
            {
                WithdrawMoney withdraw = new WithdrawMoney();
                withdraw.Transaction();
            }
            
        }

        
    }
}