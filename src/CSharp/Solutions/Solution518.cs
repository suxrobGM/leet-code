using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution518
{
    /// <summary>
    /// 518. Coin Change 2 - Medium
    /// <a href="https://leetcode.com/problems/coin-change-2">See the problem</a>
    /// </summary>
    public int Change(int amount, int[] coins)
    {
        var dp = new int[amount + 1];
        dp[0] = 1;

        foreach (var coin in coins)
        {
            for (var i = coin; i <= amount; i++)
            {
                dp[i] += dp[i - coin];
            }
        }

        return dp[amount];
    }
}
