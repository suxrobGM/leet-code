namespace LeetCode.Solutions;

public class Solution221
{
    /// <summary>
    /// 221. Maximal Square - Medium
    /// <a href="https://leetcode.com/problems/maximal-square">See the problem</a>
    /// </summary>
    public int MaximalSquare(char[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var dp = new int[m + 1, n + 1];
        var max = 0;

        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (matrix[i - 1][j - 1] == '1')
                {
                    dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])) + 1;
                    max = Math.Max(max, dp[i, j]);
                }
            }
        }

        return max * max;
    }
}
