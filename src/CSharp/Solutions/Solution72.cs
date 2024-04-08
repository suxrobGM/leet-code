namespace LeetCode.Solutions;

public class Solution72
{
    /// <summary>
    /// 72. Edit Distance - Medium
    /// <a href="https://leetcode.com/problems/edit-distance">See the problem</a>
    /// </summary>
    public int MinDistance(string word1, string word2)
    {
        var m = word1.Length;
        var n = word2.Length;
        var dp = new int[m + 1, n + 1];

        // Initialize the first row
        for (var i = 0; i <= m; i++)
        {
            dp[i, 0] = i;
        }

        // Initialize the first column
        for (var j = 0; j <= n; j++)
        {
            dp[0, j] = j;
        }

        // Fill in the rest of the DP table
        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = 1 + Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1]));
                }
            }
        }

        return dp[m, n];
    }
}
