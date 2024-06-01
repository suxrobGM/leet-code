namespace LeetCode.Solutions;

public class Solution153
{
    /// <summary>
    /// 153. Find Minimum in Rotated Sorted Array - Medium
    /// <a href="https://leetcode.com/problems/find-minimum-in-rotated-sorted-array">See the problem</a>
    /// </summary>
    public int FindMin(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] < nums[right])
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return nums[left];
    }
}
