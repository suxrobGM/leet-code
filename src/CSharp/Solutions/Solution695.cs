using System.Text;

namespace LeetCode.Solutions;

public class Solution695
{
    /// <summary>
    /// 695. Max Area of Island - Medium
    /// <a href="https://leetcode.com/problems/max-area-of-island">See the problem</a>
    /// </summary>
    public int MaxAreaOfIsland(int[][] grid)
    {
        var maxArea = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    maxArea = Math.Max(maxArea, GetArea(grid, i, j));
                }
            }
        }

        return maxArea;
    }

    private int GetArea(int[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == 0)
        {
            return 0;
        }

        grid[i][j] = 0;
        return 1 + GetArea(grid, i + 1, j) + GetArea(grid, i - 1, j) + GetArea(grid, i, j + 1) + GetArea(grid, i, j - 1);
    }
}
