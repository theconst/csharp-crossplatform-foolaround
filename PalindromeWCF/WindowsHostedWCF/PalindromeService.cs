using PalindromeWCF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHostedWCF
{
    public class CalculatorWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public CalculatorWindowsService()
        {
            // Name the Windows Service
            ServiceName = "WCFPalindromeWindowsHosted";
        }
        public static void Main()
        {
            ServiceBase.Run(new CalculatorWindowsService());
        }
        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            string path = @"d:\temp\except.txt";
            StreamWriter sw = File.CreateText(path);
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            try
            {
                serviceHost =
                new ServiceHost(typeof(PalindromeService));
                serviceHost.Open();
            }
            catch (Exception e)
            {
                sw.WriteLine("The process failed: {0}",
                e.ToString());
            }
            finally { sw.Close(); }
        }
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
