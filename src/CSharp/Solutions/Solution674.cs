using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution674
{
    /// <summary>
    /// 674. Longest Continuous Increasing Subsequence - Easy
    /// <a href="https://leetcode.com/problems/longest-continuous-increasing-subsequence">See the problem</a>
    /// </summary>
    public int FindLengthOfLCIS(int[] nums)
    {
        var n = nums.Length;
        var maxLength = 0;
        var currentLength = 0;

        for (var i = 0; i < n; i++)
        {
            if (i == 0 || nums[i] > nums[i - 1])
            {
                currentLength++;
            }
            else
            {
                maxLength = Math.Max(maxLength, currentLength);
                currentLength = 1;
            }
        }

        return Math.Max(maxLength, currentLength);
    }
}
