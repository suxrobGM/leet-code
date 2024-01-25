namespace LeetCode.Solutions;

public class Solution122
{
    /// <summary>
    /// 122. Best Time to Buy and Sell Stock II
    /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii">See the problem</a>
    /// </summary>
    public int MaxProfit(int[] prices)
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
}
