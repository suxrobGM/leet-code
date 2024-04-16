using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution87
{
    /// <summary>
    /// 87. Scramble String - Hard
    /// <a href="https://leetcode.com/problems/scramble-string">See the problem</a>
    /// </summary>
    public bool IsScramble(string s1, string s2)
    {
        if (s1 == s2)
        {
            return true;
        }

        if (s1.Length != s2.Length)
        {
            return false;
        }

        var n = s1.Length;
        var dp = new bool[n, n, n + 1];

        for (var len = 1; len <= n; len++)
        {
            for (var i = 0; i <= n - len; i++)
            {
                for (var j = 0; j <= n - len; j++)
                {
                    if (len == 1)
                    {
                        dp[i, j, len] = s1[i] == s2[j];
                    }
                    else
                    {
                        for (var k = 1; k < len && !dp[i, j, len]; k++)
                        {
                            dp[i, j, len] = dp[i, j, k] && dp[i + k, j + k, len - k] ||
                                            dp[i, j + len - k, k] && dp[i + k, j, len - k];
                        }
                    }
                }
            }
        }

        return dp[0, 0, n];
    }
}
