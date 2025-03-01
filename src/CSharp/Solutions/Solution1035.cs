using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1035
{
    /// <summary>
    /// 1035. Uncrossed Lines - Medium
    /// <a href="https://leetcode.com/problems/uncrossed-lines</a>
    /// </summary>
    public int MaxUncrossedLines(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        var dp = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (nums1[i - 1] == nums2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[m, n];
    }
}
