using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1162
{
    /// <summary>
    /// 1162. As Far from Land as Possible - Medium
    /// <a href="https://leetcode.com/problems/as-far-from-land-as-possible">See the problem</a>
    /// </summary>
    public int MaxDistance(int[][] grid)
    {
        var n = grid.Length;
        var queue = new Queue<(int, int)>();
        var directions = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
        var maxDistance = -1;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    queue.Enqueue((i, j));
                }
            }
        }

        while (queue.Count > 0)
        {
            var size = queue.Count;
            maxDistance++;

            for (var i = 0; i < size; i++)
            {
                var (x, y) = queue.Dequeue();

                foreach (var (dx, dy) in directions)
                {
                    var newX = x + dx;
                    var newY = y + dy;

                    if (newX >= 0 && newX < n && newY >= 0 && newY < n && grid[newX][newY] == 0)
                    {
                        grid[newX][newY] = 1;
                        queue.Enqueue((newX, newY));
                    }
                }
            }
        }

        return maxDistance == 0 ? -1 : maxDistance;
    }
}
