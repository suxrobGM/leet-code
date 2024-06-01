namespace LeetCode.Solutions;

public class Solution152
{
    /// <summary>
    /// 152. Maximum Product Subarray - Medium
    /// <a href="https://leetcode.com/problems/maximum-product-subarray">See the problem</a>
    /// </summary>
    public int MaxProduct(int[] nums)
    {
        var max = nums[0];
        var min = nums[0];
        var result = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            var tempMax = Math.Max(num, Math.Max(max * num, min * num));
            min = Math.Min(num, Math.Min(max * num, min * num));
            max = tempMax;
            result = Math.Max(result, max);
        }

        return result;
    }
}
