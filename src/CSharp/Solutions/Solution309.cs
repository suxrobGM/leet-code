namespace LeetCode.Solutions;

public class Solution309
{
    /// <summary>
    /// 309. Best Time to Buy and Sell Stock with Cooldown - Medium
    /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown">See the problem</a>
    /// </summary>
    public int MaxProfit(int[] prices)
    {
        var n = prices.Length;
        if (n == 0)
        {
            return 0;
        }

        var dp = new int[n, 2];
        dp[0, 0] = 0;
        dp[0, 1] = -prices[0];

        for (var i = 1; i < n; i++)
        {
            if (i == 1)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
            }
            else
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 2, 0] - prices[i]);
            }
        }

        return dp[n - 1, 0];
    }
}
