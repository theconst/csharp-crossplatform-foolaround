using System;
using static CommonDivisorLibrary.LongestWordFinder;
using static CommonDivisorLibrary.CommonMultiple;

namespace WinPromptingApplication
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");
            int number = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter arbitrary text:");
            string text = Console.ReadLine();
            string longestWord = FindLongestWord(text);

            Console.WriteLine($"The longest word in text is '{longestWord}'");
            Console.WriteLine($"Your lucky number is {FindLeastCommonMultiple(number, longestWord.Length)}");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
