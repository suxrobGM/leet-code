using System.Text;

namespace LeetCode.Solutions;

public class Solution807
{
    /// <summary>
    /// 807. Max Increase to Keep City Skyline - Medium
    /// <a href="https://leetcode.com/problems/max-increase-to-keep-city-skyline">See the problem</a>
    /// </summary>
    public int MaxIncreaseKeepingSkyline(int[][] grid)
    {
        var n = grid.Length;
        var rowMax = new int[n];
        var colMax = new int[n];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                rowMax[i] = Math.Max(rowMax[i], grid[i][j]);
                colMax[j] = Math.Max(colMax[j], grid[i][j]);
            }
        }

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                result += Math.Min(rowMax[i], colMax[j]) - grid[i][j];
            }
        }

        return result;
    }
}
