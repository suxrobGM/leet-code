using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1293
{
    /// <summary>
    /// 1293. Shortest Path in a Grid with Obstacles Elimination - Hard
    /// <a href="https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination">See the problem</a>
    /// </summary>
    public int ShortestPath(int[][] grid, int k)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var directions = new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        var queue = new Queue<(int x, int y, int obstacles, int steps)>();
        var visited = new bool[rows, cols, k + 1];

        queue.Enqueue((0, 0, 0, 0));
        visited[0, 0, 0] = true;

        while (queue.Count > 0)
        {
            var (x, y, obstacles, steps) = queue.Dequeue();

            if (x == rows - 1 && y == cols - 1)
            {
                return steps;
            }

            foreach (var (dx, dy) in directions)
            {
                int newX = x + dx;
                int newY = y + dy;

                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols)
                {
                    int newObstacles = obstacles + grid[newX][newY];
                    if (newObstacles <= k && !visited[newX, newY, newObstacles])
                    {
                        visited[newX, newY, newObstacles] = true;
                        queue.Enqueue((newX, newY, newObstacles, steps + 1));
                    }
                }
            }
        }

        return -1;
    }
}
