using System.Text;

namespace LeetCode.Solutions;

public class Solution812
{
    /// <summary>
    /// 812. Largest Triangle Area - Easy
    /// <a href="https://leetcode.com/problems/largest-triangle-area">See the problem</a>
    /// </summary>
    public double LargestTriangleArea(int[][] points)
    {
        var n = points.Length;
        var result = 0.0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                for (var k = j + 1; k < n; k++)
                {
                    var area = Math.Abs(points[i][0] * (points[j][1] - points[k][1]) +
                                        points[j][0] * (points[k][1] - points[i][1]) +
                                        points[k][0] * (points[i][1] - points[j][1])) / 2.0;

                    result = Math.Max(result, area);
                }
            }
        }

        return result;
    }
}
