using System.Text;

namespace LeetCode.Solutions;

public class Solution1833
{
    /// <summary>
    /// 1833. Maximum Ice Cream Bars - Medium
    /// <a href="https://leetcode.com/problems/maximum-ice-cream-bars">See the problem</a>
    /// </summary>
    public int MaxIceCream(int[] costs, int coins)
    {
        Array.Sort(costs);
        int count = 0;
        foreach (int cost in costs)
        {
            if (coins >= cost)
            {
                coins -= cost;
                count++;
            }
            else
            {
                break;
            }
        }

        return count;
    }
}
