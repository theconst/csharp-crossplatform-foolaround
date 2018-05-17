using System;
using static CommonDivisorLibrary.CommonDivisor;

namespace CommonDivisorLibrary
{
    public class CommonMultiple
    {
        public static int FindLeastCommonMultiple(int m, int n) => 
           (m == 0 || n == 0) ? 0 : (Math.Abs(m) / (FindLargestCommonDivisor(n, m))) * Math.Abs(n);

    }
}
