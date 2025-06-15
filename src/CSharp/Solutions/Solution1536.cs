using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1536
{
    /// <summary>
    /// 1536. Minimum Swaps to Arrange a Binary Grid - Medium
    /// <a href="https://leetcode.com/problems/minimum-swaps-to-arrange-a-binary-grid">See the problem</a>
    /// </summary>
    public int MinSwaps(int[][] grid)
    {
        int n = grid.Length;
        int[] zeros = new int[n];

        // Count trailing zeros in each row
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = n - 1; j >= 0 && grid[i][j] == 0; j--)
            {
                count++;
            }
            zeros[i] = count;
        }

        int swaps = 0;

        // Try to arrange the grid
        for (int i = 0; i < n; i++)
        {
            if (zeros[i] < n - i - 1)
            {
                // Find a row that can be swapped with the current row
                int j = i + 1;
                while (j < n && zeros[j] < n - i - 1)
                {
                    j++;
                }

                if (j == n) return -1; // No valid swap found

                // Swap rows
                while (j > i)
                {
                    (zeros[j], zeros[j - 1]) = (zeros[j - 1], zeros[j]);
                    swaps++;
                    j--;
                }
            }
        }

        return swaps;
    }
}
