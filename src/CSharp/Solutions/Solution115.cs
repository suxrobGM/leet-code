using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution115
{
    /// <summary>
    /// 115. Distinct Subsequences - Hard
    /// <a href="https://leetcode.com/problems/distinct-subsequences">See the problem</a>
    /// </summary>
    public int NumDistinct(string s, string t)
    {
        var dp = new int[t.Length + 1];
        dp[0] = 1;

        for (var i = 1; i <= s.Length; i++)
        {
            for (var j = t.Length; j >= 1; j--)
            {
                if (s[i - 1] == t[j - 1])
                {
                    dp[j] += dp[j - 1];
                }
            }
        }

        return dp[t.Length];
    }
}
