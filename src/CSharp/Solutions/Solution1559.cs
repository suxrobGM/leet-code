using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1559
{
    /// <summary>
    /// 1559. Detect Cycles in 2D Grid - Medium
    /// <a href="https://leetcode.com/problems/detect-cycles-in-2d-grid">See the problem</a>
    /// </summary>
    public bool ContainsCycle(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        bool[,] visited = new bool[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (!visited[i, j] && DFS(grid, visited, i, j, -1, -1, grid[i][j]))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool DFS(char[][] grid, bool[,] visited, int x, int y, int prevX, int prevY, char target)
    {
        if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || grid[x][y] != target)
        {
            return false;
        }

        if (visited[x, y])
        {
            return true;
        }

        visited[x, y] = true;

        // Explore all four directions
        int[] dx = [-1, 1, 0, 0];
        int[] dy = [0, 0, -1, 1];

        for (int i = 0; i < 4; i++)
        {
            if (x + dx[i] != prevX || y + dy[i] != prevY)
            {
                if (DFS(grid, visited, x + dx[i], y + dy[i], x, y, target))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
