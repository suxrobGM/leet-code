namespace LeetCode.Solutions;

public class Solution154
{
    /// <summary>
    /// 154. Find Minimum in Rotated Sorted Array II - Hard
    /// <a href="https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii">See the problem</a>
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
            else if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else
            {
                right--;
            }
        }

        return nums[left];
    }
}
