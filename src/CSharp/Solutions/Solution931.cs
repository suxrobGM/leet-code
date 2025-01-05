using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution931
{
    /// <summary>
    /// 931. Minimum Falling Path Sum - Medium
    /// <a href="https://leetcode.com/problems/minimum-falling-path-sum">See the problem</a>
    /// </summary>
    public int MinFallingPathSum(int[][] matrix)
    {
        int n = matrix.Length;
        int[,] dp = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            dp[0, i] = matrix[0][i];
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = matrix[i][j] + dp[i - 1, j];
                if (j > 0)
                {
                    dp[i, j] = Math.Min(dp[i, j], matrix[i][j] + dp[i - 1, j - 1]);
                }
                if (j < n - 1)
                {
                    dp[i, j] = Math.Min(dp[i, j], matrix[i][j] + dp[i - 1, j + 1]);
                }
            }
        }

        int result = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            result = Math.Min(result, dp[n - 1, i]);
        }

        return result;
    }
}
