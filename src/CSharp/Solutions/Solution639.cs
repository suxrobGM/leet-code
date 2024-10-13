using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution639
{
    /// <summary>
    /// 639. Decode Ways II - Hard
    /// <a href="https://leetcode.com/problems/decode-ways-ii">See the problem</a>
    /// </summary>
    public int NumDecodings(string s)
    {
        var MOD = 1000000007;
        var n = s.Length;
        var dp = new long[n + 1];
        dp[0] = 1;  // Empty string can be decoded in 1 way

        // Initialize the first character
        if (s[0] == '0') return 0;
        dp[1] = (s[0] == '*') ? 9 : 1;

        for (var i = 2; i <= n; i++)
        {
            var current = s[i - 1];
            var previous = s[i - 2];

            // Single character decoding
            if (current == '*')
            {
                dp[i] += 9 * dp[i - 1];  // '*' can be 1-9
            }
            else if (current > '0')
            {
                dp[i] += dp[i - 1];  // current is a valid single digit
            }

            // Two character decoding
            if (previous == '*')
            {
                if (current == '*')
                {
                    dp[i] += 15 * dp[i - 2]; // "**" can be 11-19, 21-26
                }
                else if (current <= '6')
                {
                    dp[i] += 2 * dp[i - 2];  // "*X" where X is 0-6, could be 10-16 or 20-26
                }
                else
                {
                    dp[i] += dp[i - 2];  // "*X" where X is 7-9, could be 17-19
                }
            }
            else if (previous == '1')
            {
                if (current == '*')
                {
                    dp[i] += 9 * dp[i - 2];  // "1*" can be 11-19
                }
                else
                {
                    dp[i] += dp[i - 2];  // "1X" can be 10-19
                }
            }
            else if (previous == '2')
            {
                if (current == '*')
                {
                    dp[i] += 6 * dp[i - 2];  // "2*" can be 21-26
                }
                else if (current <= '6')
                {
                    dp[i] += dp[i - 2];  // "2X" can be 20-26
                }
            }

            dp[i] %= MOD;  // Always take modulo to avoid overflow
        }

        return (int)dp[n];
    }
}
