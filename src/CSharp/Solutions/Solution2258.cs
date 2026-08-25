namespace LeetCode.Solutions;

public class Solution2258
{
    private const int Infinity = int.MaxValue;
    private static readonly int[] Directions = [0, 1, 0, -1, 0];

    /// <summary>
    /// 2258. Escape the Spreading Fire - Hard
    /// <a href="https://leetcode.com/problems/escape-the-spreading-fire">See the problem</a>
    /// </summary>
    public int MaximumMinutes(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var fireSources = new Queue<(int Row, int Col)>();

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (grid[row][col] == 1)
                {
                    fireSources.Enqueue((row, col));
                }
            }
        }

        var fireTime = Bfs(grid, fireSources);

        var personSources = new Queue<(int Row, int Col)>();
        personSources.Enqueue((0, 0));
        var personTime = Bfs(grid, personSources);

        var targetRow = rows - 1;
        var targetCol = cols - 1;

        if (personTime[targetRow, targetCol] == Infinity)
        {
            return -1;
        }

        if (fireTime[targetRow, targetCol] == Infinity)
        {
            return 1_000_000_000;
        }

        var wait = fireTime[targetRow, targetCol] - personTime[targetRow, targetCol];

        if (wait < 0)
        {
            return -1;
        }

        // Check the cells adjacent to the safehouse: if either the top or left neighbor
        // can be reached strictly before the fire, we can wait the full "wait" minutes.
        var topSafe = CanReachAhead(fireTime, personTime, targetRow - 1, targetCol, wait);
        var leftSafe = CanReachAhead(fireTime, personTime, targetRow, targetCol - 1, wait);

        return topSafe || leftSafe ? wait : wait - 1;
    }

    private static bool CanReachAhead(int[,] fireTime, int[,] personTime, int row, int col, int wait)
    {
        if (row < 0 || col < 0 || personTime[row, col] == Infinity)
        {
            return false;
        }

        return fireTime[row, col] == Infinity || fireTime[row, col] - personTime[row, col] > wait;
    }

    private static int[,] Bfs(int[][] grid, Queue<(int Row, int Col)> queue)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var time = new int[rows, cols];

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                time[row, col] = Infinity;
            }
        }

        foreach (var (row, col) in queue)
        {
            time[row, col] = 0;
        }

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();

            for (var dir = 0; dir < 4; dir++)
            {
                var nextRow = row + Directions[dir];
                var nextCol = col + Directions[dir + 1];

                if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols)
                {
                    continue;
                }

                if (grid[nextRow][nextCol] == 2 || time[nextRow, nextCol] != Infinity)
                {
                    continue;
                }

                time[nextRow, nextCol] = time[row, col] + 1;
                queue.Enqueue((nextRow, nextCol));
            }
        }

        return time;
    }
}
