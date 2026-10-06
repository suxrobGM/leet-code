using System.Text;

namespace LeetCode.Solutions;

public class Solution2304
{
    /// <summary>
    /// 2304. Minimum Path Cost in a Grid - Medium
    /// <a href="https://leetcode.com/problems/minimum-path-cost-in-a-grid">See the problem</a>
    /// </summary>
    public int MinPathCost(int[][] grid, int[][] moveCost)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // Create a dp array to store the minimum cost to reach each cell
        int[,] dp = new int[m, n];

        // Initialize the first row of dp with the values from the grid
        for (int j = 0; j < n; j++)
        {
            dp[0, j] = grid[0][j];
        }

        // Fill the dp array
        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = int.MaxValue;
                for (int k = 0; k < n; k++)
                {
                    int cost = dp[i - 1, k] + moveCost[grid[i - 1][k]][j] + grid[i][j];
                    dp[i, j] = Math.Min(dp[i, j], cost);
                }
            }
        }

        // Find the minimum cost in the last row of dp
        int minCost = int.MaxValue;
        for (int j = 0; j < n; j++)
        {
            minCost = Math.Min(minCost, dp[m - 1, j]);
        }

        return minCost;
    }
}
