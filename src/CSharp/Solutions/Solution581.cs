using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution581
{
    /// <summary>
    /// 581. Shortest Unsorted Continuous Subarray - Medium
    /// <a href="https://leetcode.com/problems/shortest-unsorted-continuous-subarray">See the problem</a>
    /// </summary>
    public int FindUnsortedSubarray(int[] nums)
    {
        var n = nums.Length;
        var left = 0;
        var right = n - 1;

        while (left < n - 1 && nums[left] <= nums[left + 1])
        {
            left++;
        }

        if (left == n - 1)
        {
            return 0;
        }

        while (right > 0 && nums[right] >= nums[right - 1])
        {
            right--;
        }

        var min = int.MaxValue;
        var max = int.MinValue;

        for (var i = left; i <= right; i++)
        {
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }

        while (left >= 0 && nums[left] > min)
        {
            left--;
        }

        while (right < n && nums[right] < max)
        {
            right++;
        }

        return right - left - 1;
    }
}
