using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1637
{
    /// <summary>
    /// 1637. Widest Vertical Area Between Two Points Containing No Points - Easy
    /// <a href="https://leetcode.com/problems/widest-vertical-area-between-two-points-containing-no-points">See the problem</a>
    /// </summary>
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        // Sort the points by their x-coordinates
        Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));

        int maxWidth = 0;

        // Calculate the maximum width between consecutive points
        for (int i = 1; i < points.Length; i++)
        {
            int width = points[i][0] - points[i - 1][0];
            if (width > maxWidth)
            {
                maxWidth = width;
            }
        }

        return maxWidth;
    }
}
