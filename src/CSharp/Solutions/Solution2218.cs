namespace LeetCode.Solutions;

public class Solution2218
{
    /// <summary>
    /// 2218. Maximum Value of K Coins From Piles - Hard
    /// <a href="https://leetcode.com/problems/maximum-value-of-k-coins-from-piles">See the problem</a>
    /// </summary>
    public int MaxValueOfCoins(IList<IList<int>> piles, int k)
    {
        int n = piles.Count;
        int[,] dp = new int[n + 1, k + 1];

        for (int i = 1; i <= n; i++)
        {
            var pile = piles[i - 1];
            int m = pile.Count;
            int[] prefixSum = new int[m + 1];

            for (int j = 0; j < m; j++)
            {
                prefixSum[j + 1] = prefixSum[j] + pile[j];
            }

            for (int j = 0; j <= k; j++)
            {
                dp[i, j] = dp[i - 1, j]; // Not taking any coins from the current pile

                for (int x = 1; x <= Math.Min(m, j); x++)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - x] + prefixSum[x]);
                }
            }
        }

        return dp[n, k];
    }
}
