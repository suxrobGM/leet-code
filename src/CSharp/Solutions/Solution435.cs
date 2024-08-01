namespace LeetCode.Solutions;

public class Solution435
{
    /// <summary>
    /// 435. Non-overlapping Intervals - Medium
    /// <a href="https://leetcode.com/problems/non-overlapping-intervals">See the problem</a>
    /// </summary>
    public int EraseOverlapIntervals(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return 0;
        }

        Array.Sort(intervals, (a, b) => a[1] - b[1]);

        var count = 1;
        var end = intervals[0][1];
        for (var i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] >= end)
            {
                count++;
                end = intervals[i][1];
            }
        }

        return intervals.Length - count;
    }
}
