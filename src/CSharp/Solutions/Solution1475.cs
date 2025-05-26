using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1475
{
    /// <summary>
    /// 1475. Final Prices With a Special Discount in a Shop - Easy
    /// <a href="https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop">See the problem</a>
    /// </summary>
    public int[] FinalPrices(int[] prices)
    {
        int n = prices.Length;
        var result = new int[n];
        var stack = new Stack<int>(); // Stack stores indices

        for (int i = 0; i < n; i++)
        {
            // While there's a previous index on the stack and current price <= that price
            while (stack.Count > 0 && prices[i] <= prices[stack.Peek()])
            {
                int idx = stack.Pop();
                result[idx] = prices[idx] - prices[i];
            }
            stack.Push(i);
        }

        // Remaining items with no discount
        while (stack.Count > 0)
        {
            int idx = stack.Pop();
            result[idx] = prices[idx];
        }

        return result;
    }
}
