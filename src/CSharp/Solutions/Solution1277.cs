using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1277
{
    /// <summary>
    /// 1277. Count Square Submatrices with All Ones - Medium
    /// <a href="https://leetcode.com/problems/count-square-submatrices-with-all-ones">See the problem</a>
    /// </summary>
    public int CountSquares(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        var dp = new int[m + 1, n + 1];
        int count = 0;

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (matrix[i - 1][j - 1] == 1)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1])) + 1;
                    count += dp[i, j];
                }
            }
        }

        return count;
    }
}
