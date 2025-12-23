using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1955
{
    /// <summary>
    /// 1955. Count Number of Special Subsequences - Medium
    /// <a href="https://leetcode.com/problems/count-number-of-special-subsequences">See the problem</a>
    /// </summary>
    public int CountSpecialSubsequences(int[] nums)
    {
        const int MOD = 1_000_000_007;
        long count0 = 0, count1 = 0, count2 = 0;

        foreach (var num in nums)
        {
            if (num == 0)
            {
                count0 = (2 * count0 + 1) % MOD;
            }
            else if (num == 1)
            {
                count1 = (2 * count1 + count0) % MOD;
            }
            else if (num == 2)
            {
                count2 = (2 * count2 + count1) % MOD;
            }
        }

        return (int)count2;
    }
}
