namespace LeetCode.Solutions;

public class Solution2144
{
    /// <summary>
    /// 2144. Minimum Cost of Buying Candies With Discount - Easy
    /// <a href="https://leetcode.com/problems/minimum-cost-of-buying-candies-with-discount">See the problem</a>
    /// </summary>
    public int MinimumCost(int[] cost)
    {
        Array.Sort(cost);
        int total = 0;
        for (int i = cost.Length - 1; i >= 0; i -= 3)
        {
            total += cost[i];
            if (i - 1 >= 0) total += cost[i - 1];
        }
        return total;
    }
}
