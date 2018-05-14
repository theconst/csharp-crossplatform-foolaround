using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using PermutationsDLL;

namespace PermutaionsTest
{
    [TestClass]
    public class PermutationsTest
    {
        [TestMethod]
        public void GivenNullThenWillBeEmpty()
        {
            List<int> nullList = null;

            var result = nullList.GetPermutations();

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GivenEmptyWillBeEmpty()
        {
            var emptyList = new List<int>();

            var result = emptyList.GetPermutations();

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GivenListOfObjectsWillReturnAllPermutations()
        {
            var listOfObjects = new List<string> { "a", "b", "c" };

            var actual = listOfObjects.GetPermutations().ToList();

            var expected = new List<List<string>>
            {
               new List<string> { "a", "b", "c" },
               new List<string> { "a", "c", "b" },
               new List<string> { "b", "a", "c" },
               new List<string> { "b", "c", "a" },
               new List<string> { "c", "a", "b" },
               new List<string> { "c", "b", "a" }
            };

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AllItemsAreUnique(actual);

            foreach (var p in expected.Zip(actual, (fst, snd) => 
                    new { ExpectedPermutation = fst, ActualPermutation = snd })) {
                CollectionAssert.AreEquivalent(p.ExpectedPermutation, p.ActualPermutation);
            }
        }

        [TestMethod]
        public void GivenListOfNumbersWillReturnCorrectCountOfPermutations()
        {
            List<int> longList = Enumerable.Range(0, 5).ToList();

            var actual = longList.GetPermutations().ToList();

            Assert.AreEqual(120, actual.Count);
        }
    }
}
