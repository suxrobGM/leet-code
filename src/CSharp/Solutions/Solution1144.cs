using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1144
{
    /// <summary>
    /// 1144. Decrease Elements To Make Array Zigzag - Medium
    /// <a href="https://leetcode.com/problems/decrease-elements-to-make-array-zigzag">See the problem</a>
    /// </summary>
    public int MovesToMakeZigzag(int[] nums)
    {
        var n = nums.Length;
        var even = 0;
        var odd = 0;

        for (var i = 0; i < n; i++)
        {
            var left = i > 0 ? nums[i - 1] : int.MaxValue;
            var right = i < n - 1 ? nums[i + 1] : int.MaxValue;

            if (i % 2 == 0)
            {
                even += Math.Max(0, nums[i] - Math.Min(left, right) + 1);
            }
            else
            {
                odd += Math.Max(0, nums[i] - Math.Min(left, right) + 1);
            }
        }

        return Math.Min(even, odd);
    }
}
