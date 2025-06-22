using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1563
{
    /// <summary>
    /// 1563. Stone Game V - Hard
    /// <a href="https://leetcode.com/problems/stone-game-v">See the problem</a>
    /// </summary>
    public int StoneGameV(int[] stoneValue)
    {
        int n = stoneValue.Length;
        int[] prefix = new int[n + 1];
        for (int i = 0; i < n; i++)
            prefix[i + 1] = prefix[i] + stoneValue[i];

        int[,] dp = new int[n, n];

        for (int len = 1; len < n; len++)
        {
            for (int i = 0; i + len < n; i++)
            {
                int j = i + len;
                for (int k = i; k < j; k++)
                {
                    int leftSum = prefix[k + 1] - prefix[i];
                    int rightSum = prefix[j + 1] - prefix[k + 1];

                    if (leftSum < rightSum)
                        dp[i, j] = Math.Max(dp[i, j], dp[i, k] + leftSum);
                    else if (leftSum > rightSum)
                        dp[i, j] = Math.Max(dp[i, j], dp[k + 1, j] + rightSum);
                    else
                        dp[i, j] = Math.Max(dp[i, j], Math.Max(dp[i, k], dp[k + 1, j]) + leftSum);
                }
            }
        }

        return dp[0, n - 1];
    }
}
