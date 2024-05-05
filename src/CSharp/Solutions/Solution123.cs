namespace LeetCode.Solutions;

public class Solution123
{
    /// <summary>
    /// 123. Best Time to Buy and Sell Stock III - Hard
    /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii">See the problem</a>
    /// </summary>
    public int MaxProfit(int[] prices)
    {
        var n = prices.Length;
        var dp = new int[3, 2];

        for (var i = 0; i <= 2; i++)
        {
            dp[i, 0] = 0;
            dp[i, 1] = int.MinValue;
        }

        for (var i = 0; i < n; i++)
        {
            for (var j = 1; j <= 2; j++)
            {
                dp[j, 0] = Math.Max(dp[j, 0], dp[j, 1] + prices[i]);
                dp[j, 1] = Math.Max(dp[j, 1], dp[j - 1, 0] - prices[i]);
            }
        }

        return dp[2, 0];
    }
}
