using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution994
{
    /// <summary>
    /// 994. Rotting Oranges - Medium
    /// <a href="https://leetcode.com/problems/rotting-oranges">See the problem</a>
    /// </summary>
    public int OrangesRotting(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var fresh = 0;
        var queue = new Queue<(int row, int col)>();
        var directions = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (grid[row][col] == 1)
                {
                    fresh++;
                }
                else if (grid[row][col] == 2)
                {
                    queue.Enqueue((row, col));
                }
            }
        }

        if (fresh == 0)
        {
            return 0;
        }

        var minutes = 0;

        while (queue.Count > 0)
        {
            minutes++;

            var size = queue.Count;

            for (var i = 0; i < size; i++)
            {
                var (row, col) = queue.Dequeue();

                foreach (var (dx, dy) in directions)
                {
                    var newRow = row + dx;
                    var newCol = col + dy;

                    if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow][newCol] != 1)
                    {
                        continue;
                    }

                    grid[newRow][newCol] = 2;
                    fresh--;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        return fresh == 0 ? minutes - 1 : -1;
    }
}
