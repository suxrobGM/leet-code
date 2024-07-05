namespace LeetCode.Solutions;

public class Solution312
{
    /// <summary>
    /// 312. Burst Balloons - Hard
    /// <a href="https://leetcode.com/problems/burst-balloons">See the problem</a>
    /// </summary>
    public int MaxCoins(int[] nums)
    {
        var n = nums.Length;
        var dp = new int[n + 2, n + 2];

        var newNums = new int[n + 2];
        newNums[0] = 1;
        newNums[n + 1] = 1;
        for (var i = 1; i <= n; i++)
        {
            newNums[i] = nums[i - 1];
        }

        for (var len = 1; len <= n; len++)
        {
            for (var i = 1; i <= n - len + 1; i++)
            {
                var j = i + len - 1;
                for (var k = i; k <= j; k++)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i, k - 1] + dp[k + 1, j] + newNums[i - 1] * newNums[k] * newNums[j + 1]);
                }
            }
        }

        return dp[1, n];
    }
}
