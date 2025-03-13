using System.Text;

namespace LeetCode.Solutions;

public class Solution1092
{
    /// <summary>
    /// 1092. Shortest Common Supersequence - Hard
    /// <a href="https://leetcode.com/problems/shortest-common-supersequence">See the problem</a>
    /// </summary>
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        var n = str1.Length;
        var m = str2.Length;
        var dp = new int[n + 1, m + 1];

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                if (i == 0 || j == 0)
                {
                    dp[i, j] = 0;
                }
                else if (str1[i - 1] == str2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        var result = new StringBuilder();
        var i1 = n;
        var i2 = m;

        while (i1 > 0 && i2 > 0)
        {
            if (str1[i1 - 1] == str2[i2 - 1])
            {
                result.Insert(0, str1[i1 - 1]);
                i1--;
                i2--;
            }
            else if (dp[i1 - 1, i2] > dp[i1, i2 - 1])
            {
                result.Insert(0, str1[i1 - 1]);
                i1--;
            }
            else
            {
                result.Insert(0, str2[i2 - 1]);
                i2--;
            }
        }

        while (i1 > 0)
        {
            result.Insert(0, str1[i1 - 1]);
            i1--;
        }

        while (i2 > 0)
        {
            result.Insert(0, str2[i2 - 1]);
            i2--;
        }

        return result.ToString();
    }
}
