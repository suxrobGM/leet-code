using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1582
{
    /// <summary>
    /// 1582. Special Positions in a Binary Matrix - Easy
    /// <a href="https://leetcode.com/problems/special-positions-in-a-binary-matrix">See the problem</a>
    /// </summary>
    public int NumSpecial(int[][] mat)
    {
        int rows = mat.Length;
        int cols = mat[0].Length;
        int[] rowSums = new int[rows];
        int[] colSums = new int[cols];

        // Calculate row and column sums
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i][j] == 1)
                {
                    rowSums[i]++;
                    colSums[j]++;
                }
            }
        }

        int specialCount = 0;

        // Count special positions
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i][j] == 1 && rowSums[i] == 1 && colSums[j] == 1)
                {
                    specialCount++;
                }
            }
        }

        return specialCount;
    }
}
