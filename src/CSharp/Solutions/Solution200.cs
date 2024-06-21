using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution200
{
    /// <summary>
    /// 200. Number of Islands - Medium
    /// <a href="https://leetcode.com/problems/number-of-islands">See the problem</a>
    /// </summary>
    public int NumIslands(char[][] grid)
    {
        var count = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    count++;
                    Dfs(grid, i, j);
                }
            }
        }
        return count;
    }

    private void Dfs(char[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
        {
            return;
        }

        grid[i][j] = '0';
        Dfs(grid, i + 1, j);
        Dfs(grid, i - 1, j);
        Dfs(grid, i, j + 1);
        Dfs(grid, i, j - 1);
    }
}
