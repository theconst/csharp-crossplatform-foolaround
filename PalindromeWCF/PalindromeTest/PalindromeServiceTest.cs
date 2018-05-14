using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromeWCF;

namespace PalindromeTest
{
    [TestClass]
    public class PalidromeServiceTest
    {
        private PalindromeService sut = new PalindromeService();

        [TestMethod]
        public void ShouldReturnStringAsPrefixForOddPalindrome()
        {
            string input = "madamimadam";

            string result = sut.GetLongestPalindromePrefix(input);

            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void ShouldReturnLongestPalindromePrefixForOddPalindrome()
        {
            string input = "madamimadamto";

            string result = sut.GetLongestPalindromePrefix(input);

            Assert.AreEqual("madamimadam", result);
        }

        [TestMethod]
        public void ShouldReturnLongestPalindromePrefixForEvenPalindrome()
        {
            string input = "moom";

            string result = sut.GetLongestPalindromePrefix(input);

            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void ShouldReturnEmptyStringForEmptyPalindrome()
        {
            Assert.AreEqual("", sut.GetLongestPalindromePrefix(""));
        }

        [TestMethod]
        public void ShouldReturnNullForNull()
        {
            Assert.IsNull(sut.GetLongestPalindromePrefix(null));
        }
    }
}
