using System.Security.Principal;

namespace ATM_Machine
{
    public class Program
    {
        static void Main(string[] args)
        {
            AtmActions requests = new AtmActions();

            requests.CreateAccount();
            requests.requests();
        }

        
    }
}