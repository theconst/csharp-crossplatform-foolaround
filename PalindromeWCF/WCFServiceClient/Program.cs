using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new PalindromeServiceRef.PalindromeServiceClient())
            {
                client.Open();
                Console.WriteLine($"Endpoint: {client.Endpoint.Address}");
                var answer = "y";
                do
                {
                    Console.WriteLine("Enter palindrome: ");
                    var maybePalindrome = Console.ReadLine();

                    var longestPalindromePrefix = client.GetLongestPalindromePrefix(maybePalindrome);

                    Console.WriteLine($"Longest palindrome prefix is: {longestPalindromePrefix}");

                    Console.WriteLine("One more time? ");
                    answer = Console.ReadLine();
                } while (answer != "n");
            }
        }
    }
}
