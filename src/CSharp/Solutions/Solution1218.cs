using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1218
{
    /// <summary>
    /// 1218. Longest Arithmetic Subsequence of Given Difference - Medium
    /// <a href="https://leetcode.com/problems/longest-arithmetic-subsequence-of-given-difference">See the problem</a>
    /// </summary>
    public int LongestSubsequence(int[] arr, int difference)
    {
        var dp = new Dictionary<int, int>();
        int maxLength = 0;

        foreach (var num in arr)
        {
            if (dp.ContainsKey(num - difference))
            {
                dp[num] = dp[num - difference] + 1;
            }
            else
            {
                dp[num] = 1;
            }

            maxLength = Math.Max(maxLength, dp[num]);
        }

        return maxLength;
    }
}
