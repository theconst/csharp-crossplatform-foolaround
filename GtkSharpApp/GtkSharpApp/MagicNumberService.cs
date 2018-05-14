
using static CommonDivisorLibrary.CommonMultiple;
using static CommonDivisorLibrary.LongestWordFinder;

namespace GtkSharpApp
{
    public static class MagicNumberService
    {
        public static int GetMagicNumber(int number, string text) {
            string longestWord = FindLongestWord(text ?? "");
            int result = FindLeastCommonMultiple(number, longestWord.Length);

            return result;
        }
    }
}
