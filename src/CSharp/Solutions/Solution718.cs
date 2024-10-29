using System.Text;

namespace LeetCode.Solutions;

public class Solution718
{
    /// <summary>
    /// 718. Maximum Length of Repeated Subarray - Medium
    /// <a href="https://leetcode.com/problems/maximum-length-of-repeated-subarray">See the problem</a>
    /// </summary>
    public int FindLength(int[] nums1, int[] nums2)
    {
        var m = nums1.Length;
        var n = nums2.Length;
        var dp = new int[m + 1, n + 1];
        var maxLength = 0;

        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (nums1[i - 1] == nums2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                    maxLength = Math.Max(maxLength, dp[i, j]);
                }
            }
        }

        return maxLength;
    }
}
