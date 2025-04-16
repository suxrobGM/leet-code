using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1254
{
    /// <summary>
    /// 1254. Number of Closed Islands - Medium
    /// <a href="https://leetcode.com/problems/number-of-closed-islands">See the problem</a>
    /// </summary>
    public int ClosedIsland(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int closedIslands = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 0)
                {
                    if (IsClosedIsland(grid, i, j))
                    {
                        closedIslands++;
                    }
                }
            }
        }

        return closedIslands;
    }

    private bool IsClosedIsland(int[][] grid, int row, int col)
    {
        if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length)
        {
            return false;
        }

        if (grid[row][col] == 1)
        {
            return true;
        }

        grid[row][col] = 1; // Mark as visited

        bool up = IsClosedIsland(grid, row - 1, col);
        bool down = IsClosedIsland(grid, row + 1, col);
        bool left = IsClosedIsland(grid, row, col - 1);
        bool right = IsClosedIsland(grid, row, col + 1);

        return up && down && left && right;
    }
}
