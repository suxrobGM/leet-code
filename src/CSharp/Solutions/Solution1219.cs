using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1219
{
    /// <summary>
    /// 1219. Path with Maximum Gold - Medium
    /// <a href="https://leetcode.com/problems/path-with-maximum-gold">See the problem</a>
    /// </summary>
    public int GetMaximumGold(int[][] grid)
    {
        int maxGold = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] > 0)
                {
                    maxGold = Math.Max(maxGold, DFS(grid, i, j, rows, cols));
                }
            }
        }

        return maxGold;
    }

    private int DFS(int[][] grid, int x, int y, int rows, int cols)
    {
        if (x < 0 || x >= rows || y < 0 || y >= cols || grid[x][y] == 0)
            return 0;

        int gold = grid[x][y];
        grid[x][y] = 0; // Mark as visited

        int maxGold = Math.Max(Math.Max(DFS(grid, x + 1, y, rows, cols), DFS(grid, x - 1, y, rows, cols)),
            Math.Max(DFS(grid, x, y + 1, rows, cols), DFS(grid, x, y - 1, rows, cols)));

        grid[x][y] = gold; // Unmark the cell

        return gold + maxGold;
    }
}
