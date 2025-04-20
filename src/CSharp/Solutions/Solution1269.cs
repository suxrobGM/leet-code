using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1269
{
    /// <summary>
    /// 1269. Number of Ways to Stay in the Same Place After Some Steps - Hard
    /// <a href="https://leetcode.com/problems/number-of-ways-to-stay-in-the-same-place-after-some-steps">See the problem</a>
    /// </summary>
    public int NumWays(int steps, int arrLen)
    {
        const int MOD = 1_000_000_007;
        int maxPos = Math.Min(arrLen - 1, steps / 2);   // farthest index we ever need
        var dp = new int[maxPos + 1];
        var next = new int[maxPos + 1];
        dp[0] = 1;

        for (int s = 0; s < steps; ++s)
        {
            Array.Clear(next, 0, next.Length);

            for (int i = 0; i <= maxPos; ++i)
            {
                long ways = dp[i];               // stay
                if (i > 0) ways += dp[i - 1];   // from left
                if (i < maxPos) ways += dp[i + 1];   // from right
                next[i] = (int)(ways % MOD);
            }

            // swap arrays for next iteration
            (next, dp) = (dp, next);
        }

        return dp[0];
    }
}
