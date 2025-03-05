using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1049
{
    /// <summary>
    /// 1049. Last Stone Weight II - Medium
    /// <a href="https://leetcode.com/problems/last-stone-weight-ii</a>
    /// </summary>
    public int LastStoneWeightII(int[] stones)
    {
        var sum = stones.Sum();
        var target = sum / 2;
        var dp = new bool[target + 1];
        dp[0] = true;

        foreach (var stone in stones)
        {
            for (var i = target; i >= stone; i--)
            {
                dp[i] = dp[i] || dp[i - stone];
            }
        }

        for (var i = target; i >= 0; i--)
        {
            if (dp[i])
            {
                return sum - 2 * i;
            }
        }

        return 0;
    }
}
