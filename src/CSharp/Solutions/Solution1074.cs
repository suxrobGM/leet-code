using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1074
{
    /// <summary>
    /// 1074. Number of Submatrices That Sum to Target - Hard
    /// <a href="https://leetcode.com/problems/number-of-submatrices-that-sum-to-target"</a>
    /// </summary>
    public int NumSubmatrixSumTarget(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int[,] prefixSum = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                prefixSum[i, j] = matrix[i - 1][j - 1] + prefixSum[i - 1, j] + prefixSum[i, j - 1] - prefixSum[i - 1, j - 1];
            }
        }

        int count = 0;

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                for (int k = 1; k <= i; k++)
                {
                    for (int l = 1; l <= j; l++)
                    {
                        int sum = prefixSum[i, j] - prefixSum[k - 1, j] - prefixSum[i, l - 1] + prefixSum[k - 1, l - 1];
                        if (sum == target)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }
}
