using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1458
{
    /// <summary>
    /// 1458. Max Dot Product of Two Subsequences - Hard
    /// <a href="https://leetcode.com/problems/max-dot-product-of-two-subsequences">See the problem</a>
    /// </summary>
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        var dp = new int[m + 1, n + 1];

        // Initialize with int.MinValue so we know when we're not using valid pairs
        for (int i = 0; i <= m; i++)
            for (int j = 0; j <= n; j++)
                dp[i, j] = int.MinValue;

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                int product = nums1[i - 1] * nums2[j - 1];
                dp[i, j] = Math.Max(dp[i, j], product);
                dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
                dp[i, j] = Math.Max(dp[i, j], dp[i, j - 1]);
                if (dp[i - 1, j - 1] != int.MinValue)
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - 1] + product);
            }
        }

        return dp[m, n];
    }
}
