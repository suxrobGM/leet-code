namespace LeetCode.Solutions;

public class Solution704
{
    /// <summary>
    /// 704. Binary Search - Easy
    /// <a href="https://leetcode.com/problems/binary-search">See the problem</a>
    /// </summary>
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}
