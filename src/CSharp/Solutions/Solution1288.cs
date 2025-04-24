using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1288
{
    /// <summary>
    /// 1288. Remove Covered Intervals - Medium
    /// <a href="https://leetcode.com/problems/remove-covered-intervals">See the problem</a>
    /// </summary>
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) =>
            a[0] != b[0] ? a[0].CompareTo(b[0]) : b[1].CompareTo(a[1]));

        int count = 0;
        int maxEnd = 0;

        foreach (var interval in intervals)
        {
            int start = interval[0], end = interval[1];

            if (end > maxEnd)
            {
                count++;
                maxEnd = end;
            }
            // else: this interval is covered by previous one(s)
        }

        return count;
    }
}
