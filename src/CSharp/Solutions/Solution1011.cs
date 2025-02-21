using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1011
{
    /// <summary>
    /// 1011. Capacity To Ship Packages Within D Days - Medium
    /// <a href="https://leetcode.com/problems/capacity-to-ship-packages-within-d-days</a>
    /// </summary>
    public int ShipWithinDays(int[] weights, int days)
    {
        var left = 0;
        var right = 0;

        foreach (var weight in weights)
        {
            left = Math.Max(left, weight);
            right += weight;
        }

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var daysNeeded = 1;
            var currentWeight = 0;

            foreach (var weight in weights)
            {
                if (currentWeight + weight > mid)
                {
                    daysNeeded++;
                    currentWeight = 0;
                }

                currentWeight += weight;
            }

            if (daysNeeded > days)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}
