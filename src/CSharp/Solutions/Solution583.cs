using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution583
{
    /// <summary>
    /// 583. Delete Operation for Two Strings - Medium
    /// <a href="https://leetcode.com/problems/delete-operation-for-two-strings">See the problem</a>
    /// </summary>
    public int MinDistance(string word1, string word2)
    {
        var n = word1.Length;
        var m = word2.Length;

        var dp = new int[n + 1, m + 1];

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                if (i == 0 || j == 0)
                {
                    dp[i, j] = i + j;
                }
                else if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = 1 + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[n, m];
    }
}
