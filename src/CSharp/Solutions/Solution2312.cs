using System.Text;

namespace LeetCode.Solutions;

public class Solution2312
{
    /// <summary>
    /// 2312. Selling Pieces of Wood - Hard
    /// <a href="https://leetcode.com/problems/selling-pieces-of-wood">See the problem</a>
    /// </summary>
    public long SellingWood(int m, int n, int[][] prices)
    {
        var dp = new long[m + 1, n + 1];

        foreach (var p in prices)
        {
            dp[p[0], p[1]] = Math.Max(dp[p[0], p[1]], p[2]);
        }

        for (int h = 1; h <= m; h++)
        {
            for (int w = 1; w <= n; w++)
            {
                for (int i = 1; i <= h / 2; i++)
                {
                    dp[h, w] = Math.Max(dp[h, w], dp[i, w] + dp[h - i, w]);
                }

                for (int j = 1; j <= w / 2; j++)
                {
                    dp[h, w] = Math.Max(dp[h, w], dp[h, j] + dp[h, w - j]);
                }
            }
        }

        return dp[m, n];
    }
}
