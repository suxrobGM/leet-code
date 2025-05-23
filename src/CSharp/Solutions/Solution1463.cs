using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1463
{
    /// <summary>
    /// 1463. Cherry Pickup II - Hard
    /// <a href="https://leetcode.com/problems/cherry-pickup-ii">See the problem</a>
    /// </summary>
    public int CherryPickup(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Create a 3D DP array
        int[,,] dp = new int[rows, cols, cols];

        // Initialize the DP array with -1
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                for (int k = 0; k < cols; k++)
                    dp[i, j, k] = -1;

        return DFS(grid, 0, 0, cols - 1, dp);
    }

    private int DFS(int[][] grid, int row, int col1, int col2, int[,,] dp)
    {
        // Base case: if out of bounds or on a thorn
        if (col1 < 0 || col1 >= grid[0].Length || col2 < 0 || col2 >= grid[0].Length || grid[row][col1] == -1 || grid[row][col2] == -1)
            return 0;

        // If we are at the last row, return the cherries collected
        if (row == grid.Length - 1)
            return grid[row][col1] + (col1 != col2 ? grid[row][col2] : 0);

        // Check if already computed
        if (dp[row, col1, col2] != -1)
            return dp[row, col1, col2];

        // Collect cherries from current positions
        int cherries = grid[row][col1];
        if (col1 != col2)
            cherries += grid[row][col2];

        // Try all possible moves for both robots
        int maxCherries = 0;
        for (int newCol1 = -1; newCol1 <= 1; newCol1++)
        {
            for (int newCol2 = -1; newCol2 <= 1; newCol2++)
            {
                maxCherries = Math.Max(maxCherries, DFS(grid, row + 1, col1 + newCol1, col2 + newCol2, dp));
            }
        }

        // Store the result in the DP array
        dp[row, col1, col2] = cherries + maxCherries;

        return dp[row, col1, col2];
    }
}
