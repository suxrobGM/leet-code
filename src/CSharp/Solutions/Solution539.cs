using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution539
{
    /// <summary>
    /// 539. Minimum Time Difference - Medium
    /// <a href="https://leetcode.com/problems/minimum-time-difference">See the problem</a>
    /// </summary>
    public int FindMinDifference(IList<string> timePoints)
    {
        var minutes = new int[timePoints.Count];
        for (var i = 0; i < timePoints.Count; i++)
        {
            var time = timePoints[i].Split(':');
            minutes[i] = int.Parse(time[0]) * 60 + int.Parse(time[1]);
        }

        Array.Sort(minutes);
        var minDiff = int.MaxValue;
        for (var i = 1; i < minutes.Length; i++)
        {
            minDiff = Math.Min(minDiff, minutes[i] - minutes[i - 1]);
        }

        minDiff = Math.Min(minDiff, minutes[0] + 1440 - minutes[^1]);
        return minDiff;
    }
}
