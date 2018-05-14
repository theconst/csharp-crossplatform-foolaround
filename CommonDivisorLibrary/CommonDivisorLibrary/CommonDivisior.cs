using System;

namespace CommonDivisorLibrary
{
    public static class CommonDivisor
    {

        public static int FindLargestCommonDivisor(int larger, int smaller)
        {
            larger = Math.Abs(larger);
            smaller = Math.Abs(smaller);
            if (smaller > larger)
            {
                // swap
                smaller ^= larger;
                larger ^= smaller;
                smaller ^= larger;
            }
            while (smaller != 0)
            {
                smaller = larger % (larger = smaller);
            }
            return larger;
        }
        
    }
}
