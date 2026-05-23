namespace LeetCode.Solutions;

public class Solution2146
{
    /// <summary>
    /// 2146. K Highest Ranked Items Within a Price Range - Medium
    /// <a href="https://leetcode.com/problems/k-highest-ranked-items-within-a-price-range">See the problem</a>
    /// </summary>
    public IList<IList<int>> HighestRankedKItems(int[][] grid, int[] pricing, int[] start, int k)
    {
        int rows = grid.Length, cols = grid[0].Length;
        int low = pricing[0], high = pricing[1];
        var result = new List<IList<int>>();
        var visited = new bool[rows, cols];
        var queue = new Queue<int[]>();
        int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];

        queue.Enqueue(start);
        visited[start[0], start[1]] = true;

        while (queue.Count > 0 && result.Count < k)
        {
            int levelSize = queue.Count;
            var level = new List<int[]>();
            for (int i = 0; i < levelSize; i++)
            {
                var cell = queue.Dequeue();
                int r = cell[0], c = cell[1];
                int price = grid[r][c];
                if (price > 1 && price >= low && price <= high)
                {
                    level.Add([price, r, c]);
                }
                foreach (var d in dirs)
                {
                    int nr = r + d[0], nc = c + d[1];
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols
                        && !visited[nr, nc] && grid[nr][nc] != 0)
                    {
                        visited[nr, nc] = true;
                        queue.Enqueue([nr, nc]);
                    }
                }
            }

            level.Sort((a, b) =>
            {
                if (a[0] != b[0]) return a[0] - b[0];
                if (a[1] != b[1]) return a[1] - b[1];
                return a[2] - b[2];
            });

            foreach (var item in level)
            {
                if (result.Count >= k) break;
                result.Add([item[1], item[2]]);
            }
        }

        return result;
    }
}
