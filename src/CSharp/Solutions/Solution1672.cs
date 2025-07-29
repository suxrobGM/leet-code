using System.Text;


namespace LeetCode.Solutions;

public class Solution1672
{
    /// <summary>
    /// 1672. Richest Customer Wealth - Easy
    /// <a href="https://leetcode.com/problems/richest-customer-wealth">See the problem</a>
    /// </summary>
    public int MaximumWealth(int[][] accounts)
    {
        int maxWealth = 0;
        foreach (var customer in accounts)
        {
            int currentWealth = customer.Sum();
            maxWealth = Math.Max(maxWealth, currentWealth);
        }
        return maxWealth;
    }
}
