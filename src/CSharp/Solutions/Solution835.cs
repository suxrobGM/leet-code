using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution835
{
    /// <summary>
    /// 835. Image Overlap - Medium
    /// <a href="https://leetcode.com/problems/image-overlap">See the problem</a>
    /// </summary>
    public int LargestOverlap(int[][] img1, int[][] img2)
    {
        var n = img1.Length;
        var maxOverlap = 0;

        for (var dx = -n + 1; dx < n; dx++)
        {
            for (var dy = -n + 1; dy < n; dy++)
            {
                maxOverlap = Math.Max(maxOverlap, CountOverlap(img1, img2, dx, dy));
            }
        }

        return maxOverlap;
    }

    private int CountOverlap(int[][] img1, int[][] img2, int dx, int dy)
    {
        var n = img1.Length;
        var count = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i + dx < 0 || i + dx >= n || j + dy < 0 || j + dy >= n)
                {
                    continue;
                }

                count += img1[i][j] & img2[i + dx][j + dy];
            }
        }

        return count;
    }
}
