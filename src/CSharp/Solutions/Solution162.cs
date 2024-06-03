namespace LeetCode.Solutions;

public class Solution162
{
    /// <summary>
    /// 162. Find Peak Element - Medium
    /// <a href="https://leetcode.com/problems/find-peak-element">See the problem</a>
    /// </summary>
    public int FindPeakElement(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] < nums[mid + 1])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}
