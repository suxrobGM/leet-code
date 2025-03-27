using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1155
{
    /// <summary>
    /// 1155. Number of Dice Rolls With Target Sum - Medium
    /// <a href="https://leetcode.com/problems/number-of-dice-rolls-with-target-sum">See the problem</a>
    /// </summary>
    public int NumRollsToTarget(int n, int k, int target)
    {
        var dp = new int[n + 1, target + 1];
        dp[0, 0] = 1;
        var mod = 1000000007;

        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= target; j++)
            {
                for (var l = 1; l <= k; l++)
                {
                    if (j - l >= 0)
                    {
                        dp[i, j] = (dp[i, j] + dp[i - 1, j - l]) % mod;
                    }
                }
            }
        }

        return dp[n, target];
    }
}
