using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution300
{
    /// <summary>
    /// 300. Longest Increasing Subsequence - Medium
    /// <a href="https://leetcode.com/problems/longest-increasing-subsequence">See the problem</a>
    /// </summary>
    public int LengthOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        var length = 0;

        foreach (var num in nums)
        {
            var left = 0;
            var right = length;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (dp[mid] < num)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            dp[left] = num;
            if (left == length)
            {
                length++;
            }
        }

        return length;
    }
}
