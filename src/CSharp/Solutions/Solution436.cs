namespace LeetCode.Solutions;

public class Solution436
{
    /// <summary>
    /// 436. Find Right Interval - Medium
    /// <a href="https://leetcode.com/problems/find-right-interval">See the problem</a>
    /// </summary>
    public int[] FindRightInterval(int[][] intervals)
    {
        var n = intervals.Length;
        var result = new int[n];
        var sortedIntervals = new (int[], int)[n];

        for (var i = 0; i < n; i++)
        {
            sortedIntervals[i] = (intervals[i], i);
        }

        Array.Sort(sortedIntervals, (a, b) => a.Item1[0] - b.Item1[0]);

        for (var i = 0; i < n; i++)
        {
            var interval = intervals[i];
            var index = BinarySearch(sortedIntervals, interval[1]);

            result[i] = index == n ? -1 : sortedIntervals[index].Item2;
        }

        return result;
    }

    private int BinarySearch((int[], int)[] intervals, int target)
    {
        var left = 0;
        var right = intervals.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (intervals[mid].Item1[0] < target)
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
