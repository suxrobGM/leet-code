using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1139
{
    /// <summary>
    /// 1139. Largest 1-Bordered Square - Medium
    /// <a href="https://leetcode.com/problems/largest-1-bordered-square">See the problem</a>
    /// </summary>
    public int Largest1BorderedSquare(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        var dpLeft = new int[m, n];
        var dpTop = new int[m, n];

        // Step 1: Fill dpLeft and dpTop
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    dpLeft[i, j] = (j == 0) ? 1 : dpLeft[i, j - 1] + 1;
                    dpTop[i, j] = (i == 0) ? 1 : dpTop[i - 1, j] + 1;
                }
            }
        }

        // Step 2: Find the largest valid square
        int maxSide = 0;
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                int possibleSide = Math.Min(dpLeft[i, j], dpTop[i, j]);

                while (possibleSide > maxSide)
                {
                    // Check if top and left borders are valid
                    if (dpLeft[i - possibleSide + 1, j] >= possibleSide &&
                        dpTop[i, j - possibleSide + 1] >= possibleSide)
                    {
                        maxSide = possibleSide;  // Update the maximum side found
                    }

                    possibleSide--;  // Try smaller square sizes
                }
            }
        }

        return maxSide * maxSide;
    }
}
