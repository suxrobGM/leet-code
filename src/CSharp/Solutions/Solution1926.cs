using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1926
{
    /// <summary>
    /// 1926. Nearest Exit from Entrance in Maze - Medium
    /// <a href="https://leetcode.com/problems/nearest-exit-from-entrance-in-maze">See the problem</a>
    /// </summary>
    public int NearestExit(char[][] maze, int[] entrance)
    {
        int rows = maze.Length;
        int cols = maze[0].Length;
        var directions = new (int, int)[]
        {
            (1, 0), (-1, 0), (0, 1), (0, -1)
        };

        var queue = new Queue<(int, int, int)>();
        queue.Enqueue((entrance[0], entrance[1], 0));
        maze[entrance[0]][entrance[1]] = '+';

        while (queue.Count > 0)
        {
            var (x, y, steps) = queue.Dequeue();

            foreach (var (dx, dy) in directions)
            {
                int newX = x + dx;
                int newY = y + dy;

                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && maze[newX][newY] == '.')
                {
                    if (newX == 0 || newX == rows - 1 || newY == 0 || newY == cols - 1)
                    {
                        return steps + 1;
                    }

                    maze[newX][newY] = '+';
                    queue.Enqueue((newX, newY, steps + 1));
                }
            }
        }

        return -1;
    }
}
