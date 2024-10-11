using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution628
{
    /// <summary>
    /// 628. Maximum Product of Three Numbers - Easy
    /// <a href="https://leetcode.com/problems/maximum-product-of-three-numbers">See the problem</a>
    /// </summary>
    public int MaximumProduct(int[] nums)
    {
        Array.Sort(nums);
        var n = nums.Length;
        return Math.Max(nums[0] * nums[1] * nums[^1], nums[n - 1] * nums[n - 2] * nums[n - 3]);
    }
}
