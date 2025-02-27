using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1029
{
    /// <summary>
    /// 1029. Two City Scheduling - Medium
    /// <a href="https://leetcode.com/problems/two-city-scheduling</a>
    /// </summary>
    public int TwoCitySchedCost(int[][] costs)
    {
        Array.Sort(costs, (a, b) => a[0] - a[1] - (b[0] - b[1]));

        int n = costs.Length / 2;
        int totalCost = 0;

        for (int i = 0; i < n; i++)
        {
            totalCost += costs[i][0] + costs[i + n][1];
        }

        return totalCost;
    }
}
