namespace LeetCode.Solutions;

public class Solution64
{
    /// <summary>
    /// 64. Minimum Path Sum - Medium
    /// <a href="https://leetcode.com/problems/minimum-path-sum">See the problem</a>
    /// </summary>
    public int MinPathSum(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var dp = new int[m, n];

        // Initialize the top-left cell
        dp[0, 0] = grid[0][0];

        // Initialize the first column
        for (var i = 1; i < m; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        }

        // Initialize the first row
        for (var j = 1; j < n; j++)
        {
            dp[0, j] = dp[0, j - 1] + grid[0][j];
        }

        // Fill in the rest of the DP table
        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
            }
        }

        // The bottom-right cell contains the minimum path sum
        return dp[m - 1, n - 1];
    }
}
