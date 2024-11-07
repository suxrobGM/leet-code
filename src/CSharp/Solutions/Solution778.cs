using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution778
{
    private static readonly int[][] directions = [
        [1, 0], [0, 1], [-1, 0], [0, -1]
    ];

    /// <summary>
    /// 778. Swim in Rising Water - Hard
    /// <a href="https://leetcode.com/problems/swim-in-rising-water">See the problem</a>
    /// </summary>
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length;
        int left = grid[0][0];
        int right = n * n - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (CanReachDestination(grid, mid, n))
            {
                right = mid; // Try for a smaller water level
            }
            else
            {
                left = mid + 1; // Increase water level
            }
        }

        return left;
    }

    private bool CanReachDestination(int[][] grid, int t, int n)
    {
        if (grid[0][0] > t) return false;

        var queue = new Queue<(int, int)>();
        var visited = new bool[n, n];
        queue.Enqueue((0, 0));
        visited[0, 0] = true;

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            if (x == n - 1 && y == n - 1) return true;

            foreach (var direction in directions)
            {
                int nx = x + direction[0];
                int ny = y + direction[1];

                if (nx >= 0 && nx < n && ny >= 0 && ny < n && !visited[nx, ny] && grid[nx][ny] <= t)
                {
                    visited[nx, ny] = true;
                    queue.Enqueue((nx, ny));
                }
            }
        }

        return false;
    }
}
