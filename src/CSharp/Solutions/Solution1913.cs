using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1913
{
    /// <summary>
    /// 1913. Maximum Product Difference Between Two Pairs - Easy
    /// <a href="https://leetcode.com/problems/maximum-product-difference-between-two-pairs">See the problem</a>
    /// </summary>
    public int MaxProductDifference(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        return (nums[n - 1] * nums[n - 2]) - (nums[0] * nums[1]);
    }
}
