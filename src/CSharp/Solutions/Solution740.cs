using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution740
{
    /// <summary>
    /// 740. Delete and Earn - Medium
    /// <a href="https://leetcode.com/problems/delete-and-earn">See the problem</a>
    /// </summary>
    public int DeleteAndEarn(int[] nums)
    {
        var max = nums.Max();
        var sum = new int[max + 1];

        foreach (var num in nums)
        {
            sum[num] += num;
        }

        var dp = new int[max + 1];
        dp[1] = sum[1];

        for (var i = 2; i <= max; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + sum[i]);
        }

        return dp[max];
    }
}
