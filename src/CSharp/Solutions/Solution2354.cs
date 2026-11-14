using System.Numerics;

namespace LeetCode.Solutions;

public class Solution2354
{
    /// <summary>
    /// 2354. Number of Excellent Pairs - Hard
    /// <a href="https://leetcode.com/problems/number-of-excellent-pairs">See the problem</a>
    /// </summary>
    public long CountExcellentPairs(int[] nums, int k)
    {
        var counts = new int[33];
        foreach (int num in new HashSet<int>(nums))
        {
            counts[BitOperations.PopCount((uint)num)]++;
        }

        var suffixCounts = new int[34];
        for (int bits = 32; bits >= 0; bits--)
        {
            suffixCounts[bits] = suffixCounts[bits + 1] + counts[bits];
        }

        // PopCount(a | b) + PopCount(a & b) = PopCount(a) + PopCount(b).
        long pairs = 0;
        for (int bits = 0; bits <= 32; bits++)
        {
            int requiredBits = Math.Max(0, k - bits);
            if (requiredBits <= 32)
            {
                // Count ordered pairs, including pairing a value with itself.
                pairs += (long)counts[bits] * suffixCounts[requiredBits];
            }
        }

        return pairs;
    }
}
