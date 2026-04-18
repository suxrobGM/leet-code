using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2104
{
    /// <summary>
    /// 2104. Sum of Subarray Ranges - Medium
    /// <a href="https://leetcode.com/problems/sum-of-subarray-ranges">See the problem</a>
    /// </summary>
    public long SubArrayRanges(int[] nums)
    {
        var n = nums.Length;
        var sum = 0L;

        for (var i = 0; i < n; i++)
        {
            var min = nums[i];
            var max = nums[i];

            for (var j = i; j < n; j++)
            {
                min = Math.Min(min, nums[j]);
                max = Math.Max(max, nums[j]);
                sum += max - min;
            }
        }

        return sum;
    }
}
