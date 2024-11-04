using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution757
{
    /// <summary>
    /// 757. Set Intersection Size At Least Two - Hard
    /// <a href="https://leetcode.com/problems/set-intersection-size-at-least-two">See the problem</a>
    /// </summary>
    public int IntersectionSizeTwo(int[][] intervals)
    {
        // Sort intervals by their end points
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        var nums = new List<int>();

        // Iterate over each interval
        foreach (var interval in intervals)
        {
            var start = interval[0];
            var end = interval[1];

            // Check the last two points in `nums` to see if they cover the interval
            var pointsInInterval = 0;
            if (nums.Count > 0 && nums[nums.Count - 1] >= start && nums[nums.Count - 1] <= end)
            {
                pointsInInterval++;
            }
            if (nums.Count > 1 && nums[nums.Count - 2] >= start && nums[nums.Count - 2] <= end)
            {
                pointsInInterval++;
            }

            // Add new points if there are less than two points covering the interval
            if (pointsInInterval < 2)
            {
                if (pointsInInterval == 0)
                {
                    // Add two points at the end of the interval
                    nums.Add(end - 1);
                    nums.Add(end);
                }
                else if (pointsInInterval == 1)
                {
                    // Add one more point at the end of the interval
                    nums.Add(end);
                }
            }
        }

        return nums.Count;
    }
}
