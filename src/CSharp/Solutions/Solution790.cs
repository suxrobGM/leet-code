using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution790
{
    /// <summary>
    /// 790. Domino and Tromino Tiling - Medium
    /// <a href="https://leetcode.com/problems/domino-and-tromino-tiling">See the problem</a>
    /// </summary>
    public int NumTilings(int n)
    {
        int MOD = 1_000_000_007;

        if (n == 0) return 1;
        if (n == 1) return 1;
        if (n == 2) return 2;

        var dp = new long[n + 1];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;

        for (var i = 3; i <= n; i++)
        {
            dp[i] = (2 * dp[i - 1] + dp[i - 3]) % MOD;
        }

        return (int)dp[n];
    }
}
