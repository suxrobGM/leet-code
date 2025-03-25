using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1143
{
    /// <summary>
    /// 1143. Longest Common Subsequence - Medium
    /// <a href="https://leetcode.com/problems/longest-common-subsequence">See the problem</a>
    /// </summary>
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int n = text1.Length;
        int m = text2.Length;

        // Create a 2D DP array initialized to 0
        var dp = new int[n + 1, m + 1];

        // Fill the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        // The length of the longest common subsequence is in dp[n][m]
        return dp[n, m];
    }
}
