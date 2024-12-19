using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution908
{
    /// <summary>
    /// 908. Smallest Range I - Easy
    /// <a href="https://leetcode.com/problems/smallest-range-i">See the problem</a>
    /// </summary>
    public int SmallestRangeI(int[] nums, int k)
    {
        int min = nums[0], max = nums[0];
        foreach (var num in nums)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }
        return Math.Max(0, max - min - 2 * k);
    }
}
