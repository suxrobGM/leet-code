using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1020
{
    /// <summary>
    /// 1020. Number of Enclaves - Medium
    /// <a href="https://leetcode.com/problems/number-of-enclaves</a>
    /// </summary>
    public int NumEnclaves(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var result = 0;
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1 && (i == 0 || i == rows - 1 || j == 0 || j == cols - 1))
                {
                    Dfs(grid, i, j);
                }
            }
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1)
                {
                    result++;
                }
            }
        }

        return result;
    }

    private void Dfs(int[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0)
        {
            return;
        }

        grid[i][j] = 0;
        Dfs(grid, i + 1, j);
        Dfs(grid, i - 1, j);
        Dfs(grid, i, j + 1);
        Dfs(grid, i, j - 1);
    }
}
