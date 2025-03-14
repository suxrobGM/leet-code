using System.Text;

namespace LeetCode.Solutions;

public class Solution1094
{
    /// <summary>
    /// 1094. Car Pooling - Medium
    /// <a href="https://leetcode.com/problems/car-pooling">See the problem</a>
    /// </summary>
    public bool CarPooling(int[][] trips, int capacity)
    {
        var stops = new int[1001];

        foreach (var trip in trips)
        {
            stops[trip[1]] += trip[0];
            stops[trip[2]] -= trip[0];
        }

        var currentCapacity = 0;
        foreach (var stop in stops)
        {
            currentCapacity += stop;
            if (currentCapacity > capacity)
            {
                return false;
            }
        }

        return true;
    }
}
