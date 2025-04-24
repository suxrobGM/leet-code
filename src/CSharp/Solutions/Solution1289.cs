using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1289
{
    /// <summary>
    /// 1289. Minimum Falling Path Sum II - Hard
    /// <a href="https://leetcode.com/problems/minimum-falling-path-sum-ii">See the problem</a>
    /// </summary>
    public int MinFallingPathSum(int[][] grid)
    {
        int n = grid.Length;
        int m = grid[0].Length;

        // dp[i][j] = minimum falling path sum to cell (i, j)
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[m];
            Array.Fill(dp[i], int.MaxValue);
        }

        // Initialize the first row of dp with the first row of grid
        for (int j = 0; j < m; j++)
        {
            dp[0][j] = grid[0][j];
        }

        // Fill the dp table
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                for (int k = 0; k < m; k++)
                {
                    if (j != k) // Avoid the same column in the previous row
                    {
                        dp[i][j] = Math.Min(dp[i][j], dp[i - 1][k] + grid[i][j]);
                    }
                }
            }
        }

        // Find the minimum value in the last row of dp
        int minPathSum = int.MaxValue;
        for (int j = 0; j < m; j++)
        {
            minPathSum = Math.Min(minPathSum, dp[n - 1][j]);
        }

        return minPathSum;
    }
}
