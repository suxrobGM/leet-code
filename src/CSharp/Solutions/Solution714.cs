using System.Text;

namespace LeetCode.Solutions;

public class Solution714
{
    /// <summary>
    /// 714. Best Time to Buy and Sell Stock with Transaction Fee - Medium
    /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee">See the problem</a>
    /// </summary>
    public int MaxProfit(int[] prices, int fee)
    {
        var n = prices.Length;
        var dp = new int[n, 2];

        dp[0, 0] = 0;
        dp[0, 1] = -prices[0] - fee;

        for (var i = 1; i < n; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i] - fee);
        }

        return dp[n - 1, 0];
    }
}
