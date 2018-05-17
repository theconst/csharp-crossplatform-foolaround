using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PalindromeWCF;

namespace ChannelClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IPalindromeService> factory = null;
            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                EndpointAddress address = new EndpointAddress("http://localhost:8000/PalindromeService2");
                factory = new ChannelFactory<IPalindromeService>(binding, address);
                IPalindromeService channel = factory.CreateChannel();
                Console.Write("Enter your line: ");
                string question = Console.ReadLine();
                string answer = channel.GetLongestPalindromePrefix(question);
                Console.WriteLine("Longest palindrome prefix : {0}", answer);
                factory.Close();
            }
            catch (Exception ex)
            {
                factory?.Abort();   
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
}
