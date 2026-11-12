namespace LeetCode.Solutions;

public class Solution2352
{
    /// <summary>
    /// 2352. Equal Row and Column Pairs - Medium
    /// <a href="https://leetcode.com/problems/equal-row-and-column-pairs">See the problem</a>
    /// </summary>
    public int EqualPairs(int[][] grid)
    {
        int n = grid.Length;
        var rowCounts = new Dictionary<string, int>();

        foreach (int[] row in grid)
        {
            // Separators preserve element boundaries in each sequence.
            string key = string.Join(',', row);
            rowCounts.TryGetValue(key, out int count);
            rowCounts[key] = count + 1;
        }

        int pairs = 0;
        var column = new int[n];

        for (int c = 0; c < n; c++)
        {
            for (int r = 0; r < n; r++)
            {
                column[r] = grid[r][c];
            }

            string key = string.Join(',', column);
            if (rowCounts.TryGetValue(key, out int count))
            {
                pairs += count;
            }
        }

        return pairs;
    }
}
