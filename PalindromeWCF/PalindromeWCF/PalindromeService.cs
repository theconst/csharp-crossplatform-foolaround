using System.Collections.Generic;
using System.Linq;

namespace PalindromeWCF
{
    public class PalindromeService : IPalindromeService
    {
        private static readonly int START = 0;

        public string GetLongestPalindromePrefix(string input) => (input == null) ? null
            : (from count in ReverseRange(input.Length, input.Length) select input.Substring(START, count))
            .FirstOrDefault(IsPalindrome) ?? "";
       
        private static IEnumerable<int> ReverseRange(int from, int count)
        {
            int end = from - count;
            for (int i = from; i > end; --i)
            {
                yield return i;
            }
        }

        private static bool IsPalindrome(string input)
        {
            int len = input.Length;
            int half = len / 2;

            IEnumerable<char> left = input.Substring(0, half);
            int offset = len % 2;
            IEnumerable<char> rightRev = input.Substring(half + offset, len - half - offset).Reverse();

            return left.SequenceEqual(rightRev);
        }
    }
}
