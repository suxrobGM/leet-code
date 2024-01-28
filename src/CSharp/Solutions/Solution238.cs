namespace LeetCode.Solutions;

public class Solution238
{
    /// <summary>
    /// 238. Product of Array Except Self
    /// <a href="https://leetcode.com/problems/product-of-array-except-self">See the problem</a>
    /// </summary>
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        var product = 1;

        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = product;
            product *= nums[i];
        }

        product = 1;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= product;
            product *= nums[i];
        }

        return result;
    }
}
