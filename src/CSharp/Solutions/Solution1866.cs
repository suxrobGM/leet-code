using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1866
{
    /// <summary>
    /// 1866. Number of Ways to Rearrange Sticks With K Sticks Visible - Medium
    /// <a href="https://leetcode.com/problems/number-of-ways-to-rearrange-sticks-with-k-sticks-visible">See the problem</a>
    /// </summary>
    public int RearrangeSticks(int n, int k)
    {
        const int MOD = 1_000_000_007;

        // dp[j] = ways for current n to have exactly j visible
        // initialize for n = 0: dp[0] = 1
        var dp = new int[k + 1];
        dp[0] = 1;

        for (int i = 1; i <= n; i++)
        {
            // next[j] corresponds to dp for i sticks
            var next = new int[k + 1];

            // j visible must be in [1..min(i, k)]
            int upper = Math.Min(i, k);
            for (int j = 1; j <= upper; j++)
            {
                long addVisible = dp[j - 1];             // place stick i as the tallest (visible)
                long hideTallest = (long)(i - 1) * dp[j]; // place stick i somewhere not at front (hidden)
                next[j] = (int)((addVisible + hideTallest) % MOD);
            }

            dp = next;
        }

        return dp[k];
    }
}
