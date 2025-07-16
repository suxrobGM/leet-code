using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1631
{
    /// <summary>
    /// 1631. Path With Minimum Effort - Medium
    /// <a href="https://leetcode.com/problems/path-with-minimum-effort">See the problem</a>
    /// </summary>
    public int MinimumEffortPath(int[][] heights)
    {
        int rows = heights.Length;
        int cols = heights[0].Length;
        int[][] efforts = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            efforts[i] = new int[cols];
            Array.Fill(efforts[i], int.MaxValue);
        }

        efforts[0][0] = 0;
        var pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((0, 0), 0);

        while (pq.Count > 0)
        {
            var (x, y) = pq.Dequeue();
            if (x == rows - 1 && y == cols - 1)
                return efforts[x][y];

            foreach (var (dx, dy) in new[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
            {
                int nx = x + dx, ny = y + dy;
                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols)
                {
                    int effort = Math.Abs(heights[nx][ny] - heights[x][y]);
                    int maxEffort = Math.Max(efforts[x][y], effort);
                    if (maxEffort < efforts[nx][ny])
                    {
                        efforts[nx][ny] = maxEffort;
                        pq.Enqueue((nx, ny), maxEffort);
                    }
                }
            }
        }

        return -1; // Should never reach here
    }
}
