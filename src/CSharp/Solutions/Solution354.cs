using System.Text;

namespace LeetCode.Solutions;

public class Solution354
{
    /// <summary>
    /// 354. Russian Doll Envelopes - Hard
    /// <a href="https://leetcode.com/problems/russian-doll-envelopes">See the problem</a>
    /// </summary>
    public int MaxEnvelopes(int[][] envelopes)
    {
        Array.Sort(envelopes, (a, b) =>
        {
            if (a[0] == b[0])
            {
                return b[1] - a[1];
            }

            return a[0] - b[0];
        });

        var dp = new int[envelopes.Length];
        var result = 0;

        for (var i = 0; i < envelopes.Length; i++)
        {
            dp[i] = 1;

            for (var j = 0; j < i; j++)
            {
                if (envelopes[i][1] > envelopes[j][1])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }

            result = Math.Max(result, dp[i]);
        }

        return result;
    }
}
