using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution629
{
    /// <summary>
    /// 629. K Inverse Pairs Array - Hard
    /// <a href="https://leetcode.com/problems/k-inverse-pairs-array">See the problem</a>
    /// </summary>
    public int KInversePairs(int n, int k)
    {
        var MOD = 1000000007;

        // Initialize dp array
        var dp = new int[n + 1, k + 1];

        // Base case: When j == 0 (no inverse pairs)
        for (var i = 0; i <= n; i++)
        {
            dp[i, 0] = 1;
        }

        // Fill dp array using the recurrence relation
        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= k; j++)
            {
                dp[i, j] = (dp[i, j - 1] + dp[i - 1, j]) % MOD;
                if (j >= i)
                {
                    dp[i, j] = (dp[i, j] - dp[i - 1, j - i] + MOD) % MOD;
                }
            }
        }

        return dp[n, k];
    }
}
