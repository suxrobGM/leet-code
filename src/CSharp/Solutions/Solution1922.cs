using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1922
{
    private const long MOD = 1_000_000_007;

    /// <summary>
    /// 1922. Count Good Numbers - Medium
    /// <a href="https://leetcode.com/problems/count-good-numbers">See the problem</a>
    /// </summary>
    public int CountGoodNumbers(long n)
    {
        long evenPositions = (n + 1) / 2;   // indices 0,2,4,... -> ceil(n/2)
        long oddPositions = n / 2;         // indices 1,3,5,... -> floor(n/2)

        long countEvenChoices = ModPow(5, evenPositions); // 0,2,4,6,8
        long countOddChoices = ModPow(4, oddPositions);  // 2,3,5,7

        long result = countEvenChoices * countOddChoices % MOD;
        return (int)result;
    }

    private long ModPow(long baseVal, long exp)
    {
        long result = 1;
        baseVal %= MOD;

        while (exp > 0)
        {
            if ((exp & 1) == 1)
            {
                result = result * baseVal % MOD;
            }
            baseVal = baseVal * baseVal % MOD;
            exp >>= 1;
        }

        return result;
    }
}
