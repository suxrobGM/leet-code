using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution939
{
    /// <summary>
    /// 939. Minimum Area Rectangle - Medium
    /// <a href="https://leetcode.com/problems/minimum-area-rectangle">See the problem</a>
    /// </summary>
    public int MinAreaRect(int[][] points)
    {
        var pointSet = new HashSet<int>();
        foreach (var point in points)
        {
            pointSet.Add(point[0] * 40001 + point[1]);
        }

        int minArea = int.MaxValue;
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                if (points[i][0] == points[j][0] || points[i][1] == points[j][1])
                {
                    continue;
                }

                if (pointSet.Contains(points[i][0] * 40001 + points[j][1]) &&
                    pointSet.Contains(points[j][0] * 40001 + points[i][1]))
                {
                    minArea = Math.Min(minArea, Math.Abs(points[i][0] - points[j][0]) * Math.Abs(points[i][1] - points[j][1]));
                }
            }
        }

        return minArea == int.MaxValue ? 0 : minArea;
    }
}
