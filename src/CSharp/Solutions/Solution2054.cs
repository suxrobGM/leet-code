namespace LeetCode.Solutions;

public class Solution2054
{
    /// <summary>
    /// 2054. Two Best Non-Overlapping Events - Medium
    /// <a href="https://leetcode.com/problems/two-best-non-overlapping-events">See the problem</a>
    /// </summary>
    public int MaxTwoEvents(int[][] events)
    {
        Array.Sort(events, (a, b) => a[1].CompareTo(b[1]));
        var n = events.Length;
        var maxVal = new int[n];
        maxVal[0] = events[0][2];
        for (var i = 1; i < n; i++)
            maxVal[i] = Math.Max(maxVal[i - 1], events[i][2]);

        var result = 0;
        foreach (var e in events)
        {
            result = Math.Max(result, e[2]);
            var lo = 0;
            var hi = n - 1;
            var idx = -1;
            while (lo <= hi)
            {
                var mid = (lo + hi) / 2;
                if (events[mid][1] < e[0])
                {
                    idx = mid;
                    lo = mid + 1;
                }
                else
                    hi = mid - 1;
            }

            if (idx >= 0)
                result = Math.Max(result, e[2] + maxVal[idx]);
        }

        return result;
    }
}
