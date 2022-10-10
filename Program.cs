using System.Security.Principal;

namespace ATM_Machine
{
    public class Program
    {
        static void Main(string[] args)
        {
            AtmRequests requests = new AtmRequests();

            requests.CreateAccount();
            requests.requests();


            
            
        }

        
    }
}