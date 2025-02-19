using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1004
{
    /// <summary>
    /// 1004. Max Consecutive Ones III - Medium
    /// <a href="https://leetcode.com/problems/max-consecutive-ones-iii</a>
    /// </summary>
    public int LongestOnes(int[] nums, int k)
    {
        var left = 0;
        var right = 0;
        var zeroCount = 0;
        var maxLength = 0;

        while (right < nums.Length)
        {
            if (nums[right] == 0)
            {
                zeroCount++;
            }

            while (zeroCount > k)
            {
                if (nums[left] == 0)
                {
                    zeroCount--;
                }

                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
            right++;
        }

        return maxLength;
    }
}
