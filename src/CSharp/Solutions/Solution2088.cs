namespace LeetCode.Solutions;

public class Solution2088
{
    /// <summary>
    /// 2088. Count Fertile Pyramids in a Land - Hard
    /// <a href="https://leetcode.com/problems/count-fertile-pyramids-in-a-land">See the problem</a>
    /// </summary>
    public int CountPyramids(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var result = 0;

        // Count inverse pyramids (apex at bottom)
        var dp = new int[m][];
        for (var i = 0; i < m; i++)
            dp[i] = (int[])grid[i].Clone();

        for (var i = 1; i < m; i++)
            for (var j = 1; j < n - 1; j++)
                if (dp[i][j] == 1)
                {
                    dp[i][j] = Math.Min(dp[i - 1][j - 1], Math.Min(dp[i - 1][j], dp[i - 1][j + 1])) + 1;
                    result += dp[i][j] - 1;
                }

        // Count regular pyramids (apex at top)
        for (var i = 0; i < m; i++)
            dp[i] = (int[])grid[i].Clone();

        for (var i = m - 2; i >= 0; i--)
            for (var j = 1; j < n - 1; j++)
                if (dp[i][j] == 1)
                {
                    dp[i][j] = Math.Min(dp[i + 1][j - 1], Math.Min(dp[i + 1][j], dp[i + 1][j + 1])) + 1;
                    result += dp[i][j] - 1;
                }

        return result;
    }
}
