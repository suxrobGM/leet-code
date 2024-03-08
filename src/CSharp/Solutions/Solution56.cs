namespace LeetCode.Solutions;

public class Solution56
{
    /// <summary>
    /// 56. Merge Intervals
    /// <a href="https://leetcode.com/problems/merge-intervals">See the problem</a>
    /// </summary>
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        
        var result = new List<int[]>();
        var currentInterval = intervals[0];
        result.Add(currentInterval);
        
        foreach (var interval in intervals)
        {
            var currentEnd = currentInterval[1];
            var nextStart = interval[0];
            var nextEnd = interval[1];
            
            if (currentEnd >= nextStart)
            {
                currentInterval[1] = Math.Max(currentEnd, nextEnd);
            }
            else
            {
                currentInterval = interval;
                result.Add(currentInterval);
            }
        }
        
        return result.ToArray();
    }
}
