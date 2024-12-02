using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution861
{
    /// <summary>
    /// 861. Score After Flipping Matrix - Medium
    /// <a href="https://leetcode.com/problems/score-after-flipping-matrix">See the problem</a>
    /// </summary>
    public int MatrixScore(int[][] grid)
    {
        int m = grid.Length;    // Number of rows
        int n = grid[0].Length; // Number of columns

        // Step 1: Ensure the first column has all 1's by toggling rows
        for (int i = 0; i < m; i++)
        {
            if (grid[i][0] == 0)
            {
                ToggleRow(grid, i);
            }
        }

        // Step 2: Toggle columns to maximize 1's
        for (int j = 1; j < n; j++)
        {
            int onesCount = 0;
            for (int i = 0; i < m; i++)
            {
                if (grid[i][j] == 1)
                {
                    onesCount++;
                }
            }

            // If there are more 0's than 1's, toggle the column
            if (onesCount < m - onesCount)
            {
                ToggleColumn(grid, j);
            }
        }

        // Step 3: Calculate the score
        int score = 0;
        for (int i = 0; i < m; i++)
        {
            int rowValue = 0;
            for (int j = 0; j < n; j++)
            {
                rowValue = (rowValue << 1) | grid[i][j];
            }
            score += rowValue;
        }

        return score;
    }

    private void ToggleRow(int[][] grid, int row)
    {
        for (int j = 0; j < grid[row].Length; j++)
        {
            grid[row][j] ^= 1;
        }
    }

    private void ToggleColumn(int[][] grid, int col)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i][col] ^= 1;
        }
    }
}
