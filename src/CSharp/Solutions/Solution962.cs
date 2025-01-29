using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution962
{
    /// <summary>
    /// 962. Maximum Width Ramp - Medium
    /// <a href="https://leetcode.com/problems/maximum-width-ramp">See the problem</a>
    /// </summary>
    public int MaxWidthRamp(int[] nums)
    {
        var stack = new Stack<int>();
        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (stack.Count == 0 || nums[stack.Peek()] > nums[i])
            {
                stack.Push(i);
            }
        }

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && nums[stack.Peek()] <= nums[i])
            {
                result = Math.Max(result, i - stack.Pop());
            }
        }

        return result;
    }
}
