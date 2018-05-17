using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CommonDivisorLibrary.CommonDivisor;

namespace UnitTests
{
    [TestClass]
    public class CommonDivisorTest
    {
        [TestMethod]
        public void GivenTwoNumbersWillFindCommonDivisor1()
        {
            int actual = FindLargestCommonDivisor(28, 42);

            Assert.AreEqual(14, actual);
        }

        [TestMethod]
        public void GivenTwoNumbersWillFindOneIfNumbersAreCoprime()
        {
            int actual = FindLargestCommonDivisor(81, 92);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void GivenZeroWillReturnAnotherArgument()
        {
            int actual = FindLargestCommonDivisor(0, 10);

            Assert.AreEqual(10, actual);
        }

        [TestMethod]
        public void GivenThoZeroesWillReturnAnotherArgument()
        {
            int actual = FindLargestCommonDivisor(0, 0);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenTwoCommuttedArgsWillReturnSameResult()
        {
            int first = FindLargestCommonDivisor(3241234, 234324);
            int second = FindLargestCommonDivisor(234324, 3241234);

            Assert.AreEqual(first, second);
        }
    }
}
