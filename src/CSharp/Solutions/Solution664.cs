using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution664
{
    /// <summary>
    /// 664. Strange Printer - Hard
    /// <a href="https://leetcode.com/problems/strange-printer">See the problem</a>
    /// </summary>
    public int StrangePrinter(string s)
    {
        var n = s.Length;
        var dp = new int[n, n];

        for (var i = n - 1; i >= 0; i--)
        {
            dp[i, i] = 1;

            for (var j = i + 1; j < n; j++)
            {
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i, j - 1];
                }
                else
                {
                    var min = int.MaxValue;

                    for (var k = i; k < j; k++)
                    {
                        min = Math.Min(min, dp[i, k] + dp[k + 1, j]);
                    }

                    dp[i, j] = min;
                }
            }
        }

        return dp[0, n - 1];
    }
}
