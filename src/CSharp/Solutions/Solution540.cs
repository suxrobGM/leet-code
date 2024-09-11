using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution540
{
    /// <summary>
    /// 540. Single Element in a Sorted Array - Medium
    /// <a href="https://leetcode.com/problems/single-element-in-a-sorted-array">See the problem</a>
    /// </summary>
    public int SingleNonDuplicate(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (mid % 2 == 1)
            {
                mid--;
            }

            if (nums[mid] == nums[mid + 1])
            {
                left = mid + 2;
            }
            else
            {
                right = mid;
            }
        }

        return nums[left];
    }
}
