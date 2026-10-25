namespace LeetCode.Solutions;

public class Solution2328
{
    /// <summary>
    /// 2328. Number of Increasing Paths in a Grid - Hard
    /// <a href="https://leetcode.com/problems/number-of-increasing-paths-in-a-grid">See the problem</a>
    /// </summary>
    public int CountPaths(int[][] grid)
    {
        const int mod = 1_000_000_007;
        int rows = grid.Length;
        int cols = grid[0].Length;

        var paths = new int[rows, cols];
        var indegree = new int[rows, cols];
        var queue = new Queue<(int Row, int Col)>();
        var directions = new (int Row, int Col)[]
        {
            (-1, 0), (1, 0), (0, -1), (0, 1)
        };

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                paths[row, col] = 1;

                foreach (var direction in directions)
                {
                    int nr = row + direction.Row;
                    int nc = col + direction.Col;

                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols
                        && grid[nr][nc] < grid[row][col])
                    {
                        indegree[row, col]++;
                    }
                }

                if (indegree[row, col] == 0)
                    queue.Enqueue((row, col));
            }
        }

        int total = 0;

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            total = (total + paths[row, col]) % mod;

            foreach (var direction in directions)
            {
                int nr = row + direction.Row;
                int nc = col + direction.Col;

                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols
                    || grid[nr][nc] <= grid[row][col])
                {
                    continue;
                }

                paths[nr, nc] = (paths[nr, nc] + paths[row, col]) % mod;

                if (--indegree[nr, nc] == 0)
                    queue.Enqueue((nr, nc));
            }
        }

        return total;
    }
}
