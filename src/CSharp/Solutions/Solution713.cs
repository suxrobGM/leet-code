using System.Text;

namespace LeetCode.Solutions;

public class Solution713
{
    /// <summary>
    /// 713. Subarray Product Less Than K - Medium
    /// <a href="https://leetcode.com/problems/subarray-product-less-than-k">See the problem</a>
    /// </summary>
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1)
        {
            return 0;
        }

        var product = 1;
        var count = 0;
        var left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            product *= nums[right];

            while (product >= k)
            {
                product /= nums[left++];
            }

            count += right - left + 1;
        }

        return count;
    }
}
