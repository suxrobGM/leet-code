using System.Text;

namespace LeetCode.Solutions;

public class Solution712
{
    /// <summary>
    /// 712. Minimum ASCII Delete Sum for Two Strings - Medium
    /// <a href="https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings">See the problem</a>
    /// </summary>
    public int MinimumDeleteSum(string s1, string s2)
    {
        var m = s1.Length;
        var n = s2.Length;
        var dp = new int[m + 1, n + 1];

        for (var i = 1; i <= m; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + s1[i - 1];
        }

        for (var j = 1; j <= n; j++)
        {
            dp[0, j] = dp[0, j - 1] + s2[j - 1];
        }

        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Min(dp[i - 1, j] + s1[i - 1], dp[i, j - 1] + s2[j - 1]);
                }
            }
        }

        return dp[m, n];
    }
}
