namespace LeetCode.Solutions;

public class Solution322
{
    /// <summary>
    /// 322. Coin Change - Medium
    /// <a href="https://leetcode.com/problems/coin-change">See the problem</a>
    /// </summary>
    public int CoinChange(int[] coins, int amount)
    {
        var dp = new int[amount + 1];
        for (var i = 1; i <= amount; i++)
        {
            dp[i] = int.MaxValue;
            foreach (var coin in coins)
            {
                if (coin <= i && dp[i - coin] != int.MaxValue)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }
        return dp[amount] == int.MaxValue ? -1 : dp[amount];
    }
}
