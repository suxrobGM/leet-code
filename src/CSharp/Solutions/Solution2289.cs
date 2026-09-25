using System.Globalization;

namespace LeetCode.Solutions;

public class Solution2289
{
    /// <summary>
    /// 2289. Steps to Make Array Non-decreasing - Medium
    /// <a href="https://leetcode.com/problems/steps-to-make-array-non-decreasing">See the problem</a>
    /// </summary>
    public int TotalSteps(int[] nums)
    {
        var steps = 0;
        var stack = new Stack<(int value, int step)>();

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var currentStep = 0;

            while (stack.Count > 0 && nums[i] > stack.Peek().value)
            {
                currentStep = Math.Max(currentStep + 1, stack.Pop().step);
            }

            steps = Math.Max(steps, currentStep);
            stack.Push((nums[i], currentStep));
        }

        return steps;
    }
}
