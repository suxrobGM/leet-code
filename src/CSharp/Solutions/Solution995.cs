using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution995
{
    /// <summary>
    /// 995. Minimum Number of K Consecutive Bit Flips - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-k-consecutive-bit-flips">See the problem</a>
    /// </summary>
    public int MinKBitFlips(int[] nums, int k)
    {
        var n = nums.Length;
        var flipped = new bool[n];
        var result = 0;
        var flipCount = 0;

        for (var i = 0; i < n; i++)
        {
            if (i >= k)
            {
                flipCount -= flipped[i - k] ? 1 : 0;
            }

            if (flipCount % 2 == nums[i])
            {
                if (i + k > n)
                {
                    return -1;
                }

                flipped[i] = true;
                flipCount++;
                result++;
            }
        }

        return result;
    }
}
