using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution762
{
    /// <summary>
    /// 762. Prime Number of Set Bits in Binary Representation - Easy
    /// <a href="https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation">See the problem</a>
    /// </summary>
    public int CountPrimeSetBits(int left, int right)
    {
        var count = 0;
        var primes = new HashSet<int> { 2, 3, 5, 7, 11, 13, 17, 19 };

        for (var i = left; i <= right; i++)
        {
            var bits = 0;
            for (var n = i; n > 0; n >>= 1)
            {
                bits += n & 1;
            }

            if (primes.Contains(bits))
            {
                count++;
            }
        }

        return count;
    }
}
