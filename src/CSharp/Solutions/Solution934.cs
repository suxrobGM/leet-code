using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution934
{
    private static readonly int[][] Directions = [
        [0, 1], [1, 0],
        [0, -1], [-1, 0]
    ];

    /// <summary>
    /// 934. Shortest Bridge - Medium
    /// <a href="https://leetcode.com/problems/shortest-bridge">See the problem</a>
    /// </summary>
    public int ShortestBridge(int[][] grid)
    {
        int n = grid.Length;

        // Step 1: Identify the first island using DFS
        var firstIsland = new Queue<(int, int)>();
        bool found = false;
        for (int i = 0; i < n && !found; i++)
        {
            for (int j = 0; j < n && !found; j++)
            {
                if (grid[i][j] == 1)
                {
                    DFS(grid, i, j, firstIsland);
                    found = true;
                }
            }
        }

        // Step 2: BFS from the boundary of the first island
        int flips = 0;
        while (firstIsland.Count > 0)
        {
            int size = firstIsland.Count;
            for (int i = 0; i < size; i++)
            {
                var (x, y) = firstIsland.Dequeue();
                foreach (var dir in Directions)
                {
                    int nx = x + dir[0], ny = y + dir[1];
                    if (nx >= 0 && ny >= 0 && nx < n && ny < n)
                    {
                        if (grid[nx][ny] == 1)
                        {
                            // Reached the second island
                            return flips;
                        }
                        if (grid[nx][ny] == 0)
                        {
                            grid[nx][ny] = 2; // Mark as visited
                            firstIsland.Enqueue((nx, ny));
                        }
                    }
                }
            }
            flips++;
        }

        return -1; // Should not reach here
    }

    private void DFS(int[][] grid, int x, int y, Queue<(int, int)> queue)
    {
        int n = grid.Length;
        if (x < 0 || y < 0 || x >= n || y >= n || grid[x][y] != 1)
        {
            return;
        }

        grid[x][y] = 2; // Mark as visited
        queue.Enqueue((x, y));
        foreach (var dir in Directions)
        {
            DFS(grid, x + dir[0], y + dir[1], queue);
        }
    }
}
