using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1605
{
    /// <summary>
    /// 1605. Find Valid Matrix Given Row and Column Sums - Medium
    /// <a href="https://leetcode.com/problems/find-valid-matrix-given-row-and-column-sums">See the problem</a>
    /// </summary>
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        int m = rowSum.Length;
        int n = colSum.Length;
        int[][] result = new int[m][];
        for (int i = 0; i < m; i++)
        {
            result[i] = new int[n];
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // The value at result[i][j] is the minimum of the remaining row and column sums
                result[i][j] = Math.Min(rowSum[i], colSum[j]);
                // Update the row and column sums
                rowSum[i] -= result[i][j];
                colSum[j] -= result[i][j];
            }
        }

        return result;
    }
}
