using System.Text;

namespace LeetCode.Solutions;

public class Solution813
{
    /// <summary>
    /// 813. Largest Sum of Averages - Medium
    /// <a href="https://leetcode.com/problems/largest-sum-of-averages">See the problem</a>
    /// </summary>
    public double LargestSumOfAverages(int[] nums, int k)
    {
        var n = nums.Length;
        var sum = new int[n + 1];
        var dp = new double[n, k];

        for (var i = 0; i < n; i++)
        {
            sum[i + 1] = sum[i] + nums[i];
            dp[i, 0] = (double)sum[i + 1] / (i + 1);
        }

        for (var i = 0; i < n; i++)
        {
            for (var j = 1; j < k; j++)
            {
                for (var m = 0; m < i; m++)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[m, j - 1] + (double)(sum[i + 1] - sum[m + 1]) / (i - m));
                }
            }
        }

        return dp[n - 1, k - 1];
    }
}
