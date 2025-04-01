using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1184
{
    /// <summary>
    /// 1184. Distance Between Bus Stops - Easy
    /// <a href="https://leetcode.com/problems/distance-between-bus-stops">See the problem</a>
    /// </summary>
    public int DistanceBetweenBusStops(int[] distance, int start, int destination)
    {
        if (start > destination)
        {
            int temp = start;
            start = destination;
            destination = temp;
        }

        int totalDistance = 0;
        for (int i = 0; i < distance.Length; i++)
            totalDistance += distance[i];

        int directDistance = 0;
        for (int i = start; i < destination; i++)
            directDistance += distance[i];

        return Math.Min(directDistance, totalDistance - directDistance);
    }
}
