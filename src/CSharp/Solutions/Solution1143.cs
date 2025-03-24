using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1140
{
    /// <summary>
    /// 1140. Stone Game II - Medium
    /// <a href="https://leetcode.com/problems/stone-game-ii">See the problem</a>
    /// </summary>
    public int StoneGameII(int[] piles)
    {
        int n = piles.Length;

        // Prefix sum array to compute range sums quickly
        int[] prefixSum = new int[n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            prefixSum[i] = piles[i] + prefixSum[i + 1];
        }

        // Memoization DP array
        int[,] dp = new int[n, n + 1];

        // Initialize dp with -1 for uncomputed values
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                dp[i, j] = -1;
            }
        }

        // Recursively calculate the maximum stones Alice can get
        return MaxStones(0, 1, prefixSum, dp);
    }

    private int MaxStones(int i, int M, int[] prefixSum, int[,] dp)
    {
        int n = prefixSum.Length - 1;

        // Base case: No more piles left
        if (i >= n) return 0;

        // If already computed, return memoized result
        if (dp[i, M] != -1) return dp[i, M];

        // If Alice can take all remaining stones
        if (i + 2 * M >= n) return prefixSum[i];

        int minOpponentStones = int.MaxValue;

        // Try all possible moves
        for (int X = 1; X <= 2 * M; X++)
        {
            minOpponentStones = Math.Min(minOpponentStones, MaxStones(i + X, Math.Max(M, X), prefixSum, dp));
        }

        // Stones collected by Alice = Total stones - Min stones Bob can force
        dp[i, M] = prefixSum[i] - minOpponentStones;
        return dp[i, M];
    }
}
