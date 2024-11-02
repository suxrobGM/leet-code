using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution741
{
    /// <summary>
    /// 741. Cherry Pickup - Hard
    /// <a href="https://leetcode.com/problems/cherry-pickup">See the problem</a>
    /// </summary>
    public int CherryPickup(int[][] grid)
    {
        var n = grid.Length;
        var dp = new int[n, n, n];

        // Initialize DP array with minimum value
        for (var r1 = 0; r1 < n; r1++)
            for (var c1 = 0; c1 < n; c1++)
                for (var r2 = 0; r2 < n; r2++)
                    dp[r1, c1, r2] = int.MinValue;

        dp[0, 0, 0] = grid[0][0];

        // Fill DP array
        for (int r1 = 0; r1 < n; r1++)
        {
            for (int c1 = 0; c1 < n; c1++)
            {
                for (int r2 = 0; r2 < n; r2++)
                {
                    int c2 = r1 + c1 - r2;
                    if (c2 < 0 || c2 >= n || grid[r1][c1] == -1 || grid[r2][c2] == -1)
                    {
                        continue;
                    }

                    // Collect cherries from the current cell(s)
                    int cherries = grid[r1][c1];
                    if (r1 != r2 || c1 != c2)
                    {
                        cherries += grid[r2][c2];
                    }

                    // Update dp[r1][c1][r2] with the maximum cherries from previous steps
                    var maxCherries = int.MinValue;
                    if (r1 > 0 && r2 > 0) maxCherries = Math.Max(maxCherries, dp[r1 - 1, c1, r2 - 1]);
                    if (r1 > 0 && c2 > 0) maxCherries = Math.Max(maxCherries, dp[r1 - 1, c1, r2]);
                    if (c1 > 0 && r2 > 0) maxCherries = Math.Max(maxCherries, dp[r1, c1 - 1, r2 - 1]);
                    if (c1 > 0 && c2 > 0) maxCherries = Math.Max(maxCherries, dp[r1, c1 - 1, r2]);

                    if (maxCherries != int.MinValue)
                    {
                        dp[r1, c1, r2] = maxCherries + cherries;
                    }
                }
            }
        }

        return Math.Max(0, dp[n - 1, n - 1, n - 1]);
    }
}
