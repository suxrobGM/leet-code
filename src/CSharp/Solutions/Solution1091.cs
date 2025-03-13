using System.Text;

namespace LeetCode.Solutions;

public class Solution1091
{
    /// <summary>
    /// 1091. Shortest Path in Binary Matrix - Medium
    /// <a href="https://leetcode.com/problems/shortest-path-in-binary-matrix">See the problem</a>
    /// </summary>
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        var n = grid.Length;
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
        {
            return -1;
        }

        var directions = new int[][]
        {
            [-1, -1],
            [-1, 0],
            [-1, 1],
            [0, -1],
            [0, 1],
            [1, -1],
            [1, 0],
            [1, 1]
        };

        var queue = new Queue<int[]>();
        queue.Enqueue([0, 0]);
        grid[0][0] = 1;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var x = current[0];
            var y = current[1];

            if (x == n - 1 && y == n - 1)
            {
                return grid[x][y];
            }

            foreach (var direction in directions)
            {
                var newX = x + direction[0];
                var newY = y + direction[1];

                if (newX >= 0 && newX < n && newY >= 0 && newY < n && grid[newX][newY] == 0)
                {
                    queue.Enqueue([newX, newY]);
                    grid[newX][newY] = grid[x][y] + 1;
                }
            }
        }

        return -1;
    }
}
