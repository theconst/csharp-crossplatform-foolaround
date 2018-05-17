using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChannelDLL.ServiceReference1;

namespace ChannelDLL
{
    public class PalindromeServiceClient
    {
        public string RequestLongestPrefix(string addr, string query) //192.168.56.1:8080
        {
            ChannelFactory<IPalindromeService> factory = null;
            string answer;
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress
                address = new EndpointAddress("http://" + addr + "/MagicEightBallService");
                factory = new ChannelFactory<IPalindromeService>(binding, address);
                IPalindromeService channel = factory.CreateChannel();
                answer = channel.GetLongestPalindromePrefix(query);
                factory.Close();
            }
            catch (Exception ex)
            {
                if (factory != null)
                {
                    factory.Abort();
                }
                answer = ex.ToString();
            }
            return answer;
        }
    }
}