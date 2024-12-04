using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution864
{
    /// <summary>
    /// 864. Shortest Path to Get All Keys - Hard
    /// <a href="https://leetcode.com/problems/shortest-path-to-get-all-keys">See the problem</a>
    /// </summary>
    public int ShortestPathAllKeys(string[] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int allKeys = 0;
        (int startX, int startY) = (-1, -1);

        // Find the starting point and count the total number of keys
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                char c = grid[i][j];
                if (c == '@')
                {
                    startX = i;
                    startY = j;
                }
                else if (char.IsLower(c))
                {
                    allKeys |= (1 << (c - 'a')); // Add this key to the bitmask
                }
            }
        }

        // BFS Initialization
        var queue = new Queue<(int x, int y, int keys, int steps)>();
        var visited = new HashSet<(int, int, int)>();

        queue.Enqueue((startX, startY, 0, 0));
        visited.Add((startX, startY, 0));

        // Directions for moving in 4 cardinal directions
        int[][] directions = [
            [0, 1], [1, 0], [0, -1], [-1, 0]
        ];

        // BFS Loop
        while (queue.Count > 0)
        {
            var (x, y, keys, steps) = queue.Dequeue();

            // Check if all keys are collected
            if (keys == allKeys)
            {
                return steps;
            }

            // Explore all 4 directions
            foreach (var dir in directions)
            {
                int nx = x + dir[0], ny = y + dir[1];

                // Check bounds
                if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;

                char cell = grid[nx][ny];

                // Check walls
                if (cell == '#') continue;

                // Check locks
                if (char.IsUpper(cell) && (keys & (1 << (cell - 'A'))) == 0)
                {
                    continue; // Lock present but key not collected
                }

                // Update keys if a key is found
                int newKeys = keys;
                if (char.IsLower(cell))
                {
                    newKeys |= (1 << (cell - 'a'));
                }

                // Skip visited states
                if (!visited.Add((nx, ny, newKeys))) continue;

                // Add new state to the queue
                queue.Enqueue((nx, ny, newKeys, steps + 1));
            }
        }

        return -1; // Impossible to collect all keys
    }
}
