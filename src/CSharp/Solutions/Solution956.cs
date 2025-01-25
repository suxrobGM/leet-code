using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution956
{
    /// <summary>
    /// 956. Tallest Billboard - Hard
    /// <a href="https://leetcode.com/problems/tallest-billboard">See the problem</a>
    /// </summary>
    public int TallestBillboard(int[] rods)
    {
        int n = rods.Length;
        int sum = rods.Sum();
        int[] dp = new int[sum + 1];
        Array.Fill(dp, -1);
        dp[0] = 0;

        for (int i = 0; i < n; i++)
        {
            int[] cur = (int[])dp.Clone();
            for (int j = 0; j <= sum - rods[i]; j++)
            {
                if (dp[j] < 0)
                {
                    continue;
                }

                cur[j + rods[i]] = Math.Max(cur[j + rods[i]], dp[j]);
                cur[Math.Abs(j - rods[i])] = Math.Max(cur[Math.Abs(j - rods[i])], dp[j] + Math.Min(j, rods[i]));
            }

            dp = cur;
        }

        return dp[0];
    }
}
