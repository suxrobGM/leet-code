using System.Text;

namespace LeetCode.Solutions;

public class Solution1771
{
    /// <summary>
    /// 1771. Maximize Palindrome Length From Subsequences - Hard
    /// <a href="https://leetcode.com/problems/maximize-palindrome-length-from-subsequences">See the problem</a>
    /// </summary>
    public int LongestPalindrome(string word1, string word2)
    {
        string s = word1 + word2;
        int n1 = word1.Length, n2 = word2.Length, n = n1 + n2;
        if (n == 0) return 0;

        var dp = new int[n, n];
        for (int i = 0; i < n; i++) dp[i, i] = 1;

        int ans = 0;

        // length from 2 to n
        for (int len = 2; len <= n; len++)
        {
            for (int i = 0; i + len - 1 < n; i++)
            {
                int j = i + len - 1;

                if (s[i] == s[j])
                {
                    dp[i, j] = (len == 2) ? 2 : dp[i + 1, j - 1] + 2;

                    // ends in different strings -> valid candidate
                    if (i < n1 && j >= n1)
                        ans = Math.Max(ans, dp[i, j]);
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }

        return ans;
    }
}
