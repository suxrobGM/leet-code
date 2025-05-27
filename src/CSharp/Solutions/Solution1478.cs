using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1478
{
    /// <summary>
    /// 1478. Allocate Mailboxes - Hard
    /// <a href="https://leetcode.com/problems/allocate-mailboxes">See the problem</a>
    /// </summary>
    public int MinDistance(int[] houses, int k)
    {
        Array.Sort(houses);
        int n = houses.Length;

        // Step 1: Precompute cost[i][j] for placing one mailbox for houses[i..j]
        var cost = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int median = houses[(i + j) / 2];
                for (int x = i; x <= j; x++)
                {
                    cost[i, j] += Math.Abs(houses[x] - median);
                }
            }
        }

        // Step 2: dp[i, k] = minimum distance to serve first i houses with k mailboxes
        var dp = new int[n + 1, k + 1];
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= k; j++)
                dp[i, j] = int.MaxValue / 2;

        dp[0, 0] = 0;

        for (int i = 1; i <= n; i++)
        {
            for (int m = 1; m <= k; m++)
            {
                for (int j = 0; j < i; j++)
                {
                    dp[i, m] = Math.Min(dp[i, m], dp[j, m - 1] + cost[j, i - 1]);
                }
            }
        }

        return dp[n, k];
    }
}
