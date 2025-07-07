using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1599
{
    /// <summary>
    /// 1599. Maximum Profit of Operating a Centennial Wheel - Medium
    /// <a href="https://leetcode.com/problems/maximum-profit-of-operating-a-centennial-wheel">See the problem</a>
    /// </summary>
    public int MinOperationsMaxProfit(int[] customers, int boardingCost, int runningCost)
    {
        int waiting = 0, totalProfit = 0, maxProfit = 0;
        int rotations = 0, maxRotation = -1;
        int i = 0, n = customers.Length;

        while (i < n || waiting > 0)
        {
            if (i < n)
                waiting += customers[i];

            int boarding = Math.Min(4, waiting);
            waiting -= boarding;

            rotations++;
            totalProfit += boarding * boardingCost - runningCost;

            if (totalProfit > maxProfit)
            {
                maxProfit = totalProfit;
                maxRotation = rotations;
            }

            i++;
        }

        return maxProfit > 0 ? maxRotation : -1;
    }
}
