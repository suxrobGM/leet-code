using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1493
{
    /// <summary>
    /// 1493. Longest Subarray of 1's After Deleting One Element - Medium
    /// <a href="https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element">See the problem</a>
    /// </summary>
    public int LongestSubarray(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        int maxLength = 0;
        int left = 0;
        int zeroCount = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                zeroCount++;
            }

            while (zeroCount > 1)
            {
                if (nums[left] == 0)
                {
                    zeroCount--;
                }
                left++;
            }

            // Calculate the length of the current subarray
            maxLength = Math.Max(maxLength, right - left);
        }

        return maxLength;
    }
}
