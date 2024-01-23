namespace LeetCode.Solutions;

public class Solution121
{
    /// <summary>
    /// 121. Best Time to Buy and Sell Stock
    /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock">See the problem</a>
    /// </summary>
    public int MaxProfit(int[] prices)
    {
        var minPrice = prices[0];
        var maxProfit = 0;
        
        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            
            var currentProfit = prices[i] - minPrice;
            
            if (currentProfit > maxProfit)
            {
                maxProfit = currentProfit;
            }
        }
        
        return maxProfit;
    }
}
