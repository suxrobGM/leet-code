using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1000
{
    /// <summary>
    /// 1000. Minimum Cost to Merge Stones - Hard
    /// <a href="https://leetcode.com/problems/minimum-cost-to-merge-stones">See the problem</a>
    /// </summary>
    public int MergeStones(int[] stones, int k)
    {
        int n = stones.Length;
        if ((n - 1) % (k - 1) != 0) return -1; // Impossible condition

        int[,] dp = new int[n, n];
        int[] prefixSum = new int[n + 1];

        // Compute prefix sums for quick range sum calculation
        for (int i = 0; i < n; i++)
            prefixSum[i + 1] = prefixSum[i] + stones[i];

        // DP computation: length from k to n
        for (int length = k; length <= n; length++)
        {
            for (int i = 0; i + length <= n; i++)
            {
                int j = i + length - 1;
                dp[i, j] = int.MaxValue;

                // Try merging (i, m) and (m+1, j)
                for (int m = i; m < j; m += k - 1)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i, m] + dp[m + 1, j]);
                }

                // If we can merge the full range into 1 pile, add its cost
                if ((j - i) % (k - 1) == 0)
                {
                    dp[i, j] += prefixSum[j + 1] - prefixSum[i];
                }
            }
        }

        return dp[0, n - 1];
    }
}
