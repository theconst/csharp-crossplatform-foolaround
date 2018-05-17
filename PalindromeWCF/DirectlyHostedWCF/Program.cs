using PalindromeWCF;
using System;
using System.ServiceModel;

namespace DirectlyHostedWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                svcHost = new ServiceHost(typeof(PalindromeService));
                svcHost.Open();
                Console.WriteLine("Service is running");
            }
            catch (Exception ex)
            {
                svcHost = null;
                Console.WriteLine($"Service can not be started \n\nError Message [{ex.Message}]");
            }
            if (svcHost != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }
        }
    }
}

