using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution910
{
    /// <summary>
    /// 910. Smallest Range II - Medium
    /// <a href="https://leetcode.com/problems/smallest-range-ii">See the problem</a>
    /// </summary>
    public int SmallestRangeII(int[] nums, int k)
    {
        Array.Sort(nums);
        var n = nums.Length;
        var result = nums[n - 1] - nums[0];
        
        for (var i = 0; i < n - 1; i++)
        {
            var min = Math.Min(nums[0] + k, nums[i + 1] - k);
            var max = Math.Max(nums[n - 1] - k, nums[i] + k);
            result = Math.Min(result, max - min);
        }
        
        return result;
    }
}
