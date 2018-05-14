using System.Collections.Generic;
using System.Linq;

namespace PermutationsDLL
{ 
    public static class Permutations
    {
        public static IEnumerable<List<T>> GetPermutations<T>(this List<T> list)
        {
            if (list?.Any() != true)
            {
                yield break;
            }
            int count = list.Count;
            if (count == 1)
            {
                yield return list;
            }
            int lastIndex = count - 1;
            foreach (IList<T> subPermutation in list.GetRange(0, lastIndex).GetPermutations())
            {
                for (int i = lastIndex; i >= 0; --i)
                {
                    List<T> nextPermutation = new List<T>(subPermutation);
                    nextPermutation.Insert(i, list[lastIndex]);
                    yield return nextPermutation;
                }
            }
        }
    }

}


