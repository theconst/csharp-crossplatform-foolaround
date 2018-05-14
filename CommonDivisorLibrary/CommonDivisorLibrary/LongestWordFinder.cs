using System.Text.RegularExpressions;
using System.Linq;

namespace CommonDivisorLibrary
{
    public static class LongestWordFinder
    {
        public static string FindLongestWord(string text) =>
            Regex.Split(text, "\\W").Aggregate("", (fst, snd) => (fst.Length >= snd.Length) ? fst : snd);
    }
}
