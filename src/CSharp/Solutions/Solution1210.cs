using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1210
{
    /// <summary>
    /// 1210. Minimum Moves to Reach Target with Rotations - Hard
    /// <a href="https://leetcode.com/problems/minimum-moves-to-reach-target-with-rotations">See the problem</a>
    /// </summary>
    public int MinimumMoves(int[][] grid)
    {
        int n = grid.Length;
        int m = grid[0].Length;
        var queue = new Queue<(int x, int y, int dir, int moves)>();
        var visited = new HashSet<(int x, int y, int dir)>();

        // Initial position: (0, 0) with direction 0 (horizontal)
        queue.Enqueue((0, 0, 0, 0));
        visited.Add((0, 0, 0));

        while (queue.Count > 0)
        {
            var (x, y, dir, moves) = queue.Dequeue();

            // Check if we reached the target
            if (x == n - 1 && y == m - 2 && dir == 1)
                return moves;

            // Move forward
            if (dir == 0 && y + 1 < m && grid[x][y + 1] == 0)
            {
                var nextPos = (x, y + 1, dir);
                if (!visited.Contains(nextPos))
                {
                    visited.Add(nextPos);
                    queue.Enqueue((x, y + 1, dir, moves + 1));
                }
            }
            else if (dir == 1 && x + 1 < n && grid[x + 1][y] == 0)
            {
                var nextPos = (x + 1, y, dir);
                if (!visited.Contains(nextPos))
                {
                    visited.Add(nextPos);
                    queue.Enqueue((x + 1, y, dir, moves + 1));
                }
            }

            // Rotate
            var newDir = dir == 0 ? 1 : 0;
            if (grid[x][y] == 0 && !visited.Contains((x, y, newDir)))
            {
                visited.Add((x, y, newDir));
                queue.Enqueue((x, y, newDir, moves + 1));
            }
        }

        return -1; // If no solution found
    }
}
