using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CommonDivisorLibrary.CommonMultiple;

namespace UnitTests
{
    [TestClass]
    class CommonMultipleTest
    {
        [TestMethod]
        public void GivenTwoNumbersWillFindLeasCommonMultiple()
        {
            int actual = FindLeastCommonMultiple(3, 5);

            Assert.AreEqual(15, actual);
        }

        [TestMethod]
        public void GivenZeroWillReturnZero()
        {
            int actual = FindLeastCommonMultiple(12, 0);

            Assert.AreEqual(0, actual);
        }

    }
}
