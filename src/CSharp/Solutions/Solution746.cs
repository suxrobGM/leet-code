using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution746
{
    /// <summary>
    /// 746. Min Cost Climbing Stairs - Easy
    /// <a href="https://leetcode.com/problems/min-cost-climbing-stairs">See the problem</a>
    /// </summary>
    public int MinCostClimbingStairs(int[] cost)
    {
        var n = cost.Length;
        var dp = new int[n + 1];

        dp[0] = cost[0];
        dp[1] = cost[1];

        for (var i = 2; i < n; i++)
        {
            dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
        }

        return Math.Min(dp[n - 1], dp[n - 2]);
    }
}
