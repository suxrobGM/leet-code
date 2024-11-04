using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution764
{
    /// <summary>
    /// 764. Largest Plus Sign - Medium
    /// <a href="https://leetcode.com/problems/largest-plus-sign">See the problem</a>
    /// </summary>
    public int OrderOfLargestPlusSign(int n, int[][] mines)
    {
        var grid = new int[n, n];
        var dp = new int[n, n, 4];

        foreach (var mine in mines)
        {
            grid[mine[0], mine[1]] = 1;
        }

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i, j] == 1)
                {
                    continue;
                }

                dp[i, j, 0] = (j == 0 ? 0 : dp[i, j - 1, 0]) + 1;
                dp[i, j, 1] = (i == 0 ? 0 : dp[i - 1, j, 1]) + 1;
            }
        }

        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = n - 1; j >= 0; j--)
            {
                if (grid[i, j] == 1)
                {
                    continue;
                }

                dp[i, j, 2] = (j == n - 1 ? 0 : dp[i, j + 1, 2]) + 1;
                dp[i, j, 3] = (i == n - 1 ? 0 : dp[i + 1, j, 3]) + 1;
            }
        }

        var result = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                result = Math.Max(result, Math.Min(dp[i, j, 0], Math.Min(dp[i, j, 1], Math.Min(dp[i, j, 2], dp[i, j, 3]))));
            }
        }

        return result;
    }
}
