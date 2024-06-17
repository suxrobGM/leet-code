using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution188
{
    /// <summary>
    /// 188. Best Time to Buy and Sell Stock IV - Hard
    /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv">See the problem</a>
    /// </summary>
    public int MaxProfit(int k, int[] prices)
    {
        if (prices.Length == 0) 
        { 
            return 0;
        }

        if (k >= prices.Length / 2)
        {
            var profit = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }
            return profit;
        }

        var dp = new int[k + 1, prices.Length];

        for (var i = 1; i <= k; i++)
        {
            var localMax = dp[i - 1, 0] - prices[0];
            for (int j = 1; j < prices.Length; j++)
            {
                dp[i, j] = Math.Max(dp[i, j - 1], prices[j] + localMax);
                localMax = Math.Max(localMax, dp[i - 1, j] - prices[j]);
            }
        }

        return dp[k, prices.Length - 1];
    }
}
