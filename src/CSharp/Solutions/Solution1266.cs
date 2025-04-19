using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1266
{
    /// <summary>
    /// 1266. Minimum Time Visiting All Points - Easy
    /// <a href="https://leetcode.com/problems/minimum-moves-to-move-a-box-to-their-target-location">See the problem</a>
    /// </summary>
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        int time = 0;
        for (int i = 1; i < points.Length; ++i)
        {
            int dx = Math.Abs(points[i][0] - points[i - 1][0]);
            int dy = Math.Abs(points[i][1] - points[i - 1][1]);
            time += Math.Max(dx, dy);
        }
        return time;
    }
}
