using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution730
{
    /// <summary>
    /// 730. Count Different Palindromic Subsequences - Hard
    /// <a href="https://leetcode.com/problems/count-different-palindromic-subsequences">See the problem</a>
    /// </summary>

    public int CountPalindromicSubsequences(string s)
    {
        var n = s.Length;
        var dp = new int[n, n];
        var MOD = 1_000_000_007;

        // Single-character substrings are palindromic
        for (var i = 0; i < n; i++)
        {
            dp[i, i] = 1;
        }

        // Fill DP table for substrings of length 2 to n
        for (var len = 2; len <= n; len++)
        {
            for (var left = 0; left <= n - len; left++)
            {
                var right = left + len - 1;
                if (s[left] != s[right])
                {
                    dp[left, right] = ((dp[left + 1, right] + dp[left, right - 1]) % MOD - dp[left + 1, right - 1] + MOD) % MOD;
                }
                else
                {
                    // Expand around `s[left] == s[right]`
                    int l = left + 1, r = right - 1;
                    while (l <= r && s[l] != s[left]) l++;
                    while (l <= r && s[r] != s[right]) r--;

                    if (l > r)
                    {
                        dp[left, right] = (2 * dp[left + 1, right - 1] + 2) % MOD;
                    }
                    else if (l == r)
                    {
                        dp[left, right] = (2 * dp[left + 1, right - 1] + 1) % MOD;
                    }
                    else
                    {
                        dp[left, right] = (2 * dp[left + 1, right - 1] - dp[l + 1, r - 1] + MOD) % MOD;
                    }
                }
            }
        }

        return dp[0, n - 1];
    }
}
