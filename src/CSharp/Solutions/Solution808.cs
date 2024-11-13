using System.Text;

namespace LeetCode.Solutions;

public class Solution808
{
    /// <summary>
    /// 808. Soup Servings - Medium
    /// <a href="https://leetcode.com/problems/soup-servings">See the problem</a>
    /// </summary>
    public double SoupServings(int n)
    {
        if (n >= 5000)
        {
            return 1;
        }

        n = (n + 24) / 25;

        var dp = new double[n + 1, n + 1];

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= n; j++)
            {
                if (i == 0 && j == 0)
                {
                    dp[i, j] = 0.5;
                }
                else if (i == 0)
                {
                    dp[i, j] = 1;
                }
                else if (j == 0)
                {
                    dp[i, j] = 0;
                }
                else
                {
                    dp[i, j] = 0.25 * (dp[Math.Max(i - 4, 0), j] + dp[Math.Max(i - 3, 0), Math.Max(j - 1, 0)] + dp[Math.Max(i - 2, 0), Math.Max(j - 2, 0)] + dp[Math.Max(i - 1, 0), Math.Max(j - 3, 0)]);
                }
            }
        }

        return dp[n, n];
    }
}
