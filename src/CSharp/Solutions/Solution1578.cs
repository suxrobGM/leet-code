using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1578
{
    /// <summary>
    /// 1578. Minimum Time to Make Rope Colorful - Medium
    /// <a href="https://leetcode.com/problems/minimum-time-to-make-rope-colorful">See the problem</a>
    /// </summary>
    public int MinCost(string colors, int[] neededTime)
    {
        int totalCost = 0;
        int n = colors.Length;

        for (int i = 1; i < n; i++)
        {
            if (colors[i] == colors[i - 1])
            {
                // If the current color is the same as the previous one,
                // we need to remove one of them.
                totalCost += Math.Min(neededTime[i], neededTime[i - 1]);
                // Keep the one with the higher cost
                neededTime[i] = Math.Max(neededTime[i], neededTime[i - 1]);
            }
        }

        return totalCost;
    }
}
