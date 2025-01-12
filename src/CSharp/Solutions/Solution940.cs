using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution940
{
    /// <summary>
    /// 940. Distinct Subsequences II - Hard
    /// <a href="https://leetcode.com/problems/distinct-subsequences-ii">See the problem</a>
    /// </summary>
    public int DistinctSubseqII(string s)
    {
        const int MOD = 1000000007;
        int n = s.Length;
        var dp = new int[n + 1];
        dp[0] = 1;

        var last = new int[26];
        Array.Fill(last, -1);

        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i - 1] * 2 % MOD;
            if (last[s[i - 1] - 'a'] != -1)
            {
                dp[i] -= dp[last[s[i - 1] - 'a'] - 1];
            }
            dp[i] %= MOD;
            last[s[i - 1] - 'a'] = i;
        }

        dp[n]--;
        if (dp[n] < 0)
        {
            dp[n] += MOD;
        }

        return dp[n];
    }
}
