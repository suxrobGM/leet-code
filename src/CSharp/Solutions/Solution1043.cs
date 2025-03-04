using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1043
{
    /// <summary>
    /// 1043. Partition Array for Maximum Sum - Medium
    /// <a href="https://leetcode.com/problems/partition-array-for-maximum-sum</a>
    /// </summary>
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        var n = arr.Length;
        var dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            var max = 0;
            for (int j = 1; j <= k && i - j >= 0; j++)
            {
                max = Math.Max(max, arr[i - j]);
                dp[i] = Math.Max(dp[i], dp[i - j] + max * j);
            }
        }

        return dp[n];
    }
}
