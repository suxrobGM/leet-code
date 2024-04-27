namespace LeetCode.Solutions;

public class Solution97
{
    /// <summary>
    /// 97. Interleaving String - Medium
    /// <a href="https://leetcode.com/problems/interleaving-string">See the problem</a>
    /// </summary>
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }

        var dp = new bool[s1.Length + 1, s2.Length + 1];
        dp[0, 0] = true;

        for (var i = 1; i <= s1.Length; i++)
        {
            dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];
        }

        for (var i = 1; i <= s2.Length; i++)
        {
            dp[0, i] = dp[0, i - 1] && s2[i - 1] == s3[i - 1];
        }

        for (var i = 1; i <= s1.Length; i++)
        {
            for (var j = 1; j <= s2.Length; j++)
            {
                dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) ||
                           (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
            }
        }

        return dp[s1.Length, s2.Length];
    }
}
