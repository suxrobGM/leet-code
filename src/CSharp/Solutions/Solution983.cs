using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution983
{
    /// <summary>
    /// 983. Minimum Cost For Tickets - Medium
    /// <a href="https://leetcode.com/problems/minimum-cost-for-tickets">See the problem</a>
    /// </summary>
    public int MincostTickets(int[] days, int[] costs)
    {
        var dp = new int[days.Length + 1];
        dp[0] = 0;

        for (int i = 1; i < dp.Length; i++)
        {
            dp[i] = dp[i - 1] + costs[0];

            for (int j = i - 1; j >= 0; j--)
            {
                if (days[i - 1] - days[j] < 7)
                {
                    dp[i] = Math.Min(dp[i], dp[j] + costs[1]);
                }

                if (days[i - 1] - days[j] < 30)
                {
                    dp[i] = Math.Min(dp[i], dp[j] + costs[2]);
                }
            }
        }

        return dp[dp.Length - 1];
    }
}
