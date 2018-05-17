using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelDLL;

namespace MagicballClientByDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer, question, addr;
            Console.Write("host:port = ");
            addr = Console.ReadLine();
            do
            {
                PalindromeServiceClient palindromeService = new PalindromeServiceClient();
                Console.Write("Your line: ");
                question = Console.ReadLine();
                if (question.Length > 0)
                {
                    answer = palindromeService.RequestLongestPrefix(addr, question);
                    Console.WriteLine("Longest prefix is: {0}", answer);
                }
            } while (question.Length > 0);
        }
    }
}