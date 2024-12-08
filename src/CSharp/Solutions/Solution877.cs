using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution877
{
    /// <summary>
    /// 877. Stone Game - Medium
    /// <a href="https://leetcode.com/problems/stone-game">See the problem</a>
    /// </summary>
    public bool StoneGame(int[] piles)
    {
        int n = piles.Length;
        int[,] dp = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            dp[i, i] = piles[i];
        }

        for (int l = 2; l <= n; l++)
        {
            for (int i = 0; i <= n - l; i++)
            {
                int j = i + l - 1;
                int parity = (j + i + n) % 2;
                if (parity == 1)
                {
                    dp[i, j] = Math.Max(piles[i] + dp[i + 1, j], piles[j] + dp[i, j - 1]);
                }
                else
                {
                    dp[i, j] = Math.Min(-piles[i] + dp[i + 1, j], -piles[j] + dp[i, j - 1]);
                }
            }
        }

        return dp[0, n - 1] > 0;
    }
}
