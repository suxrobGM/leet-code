namespace LeetCode.Solutions;

public class Solution2334
{
    /// <summary>
    /// 2334. Subarray With Elements Greater Than Varying Threshold - Hard
    /// <a href="https://leetcode.com/problems/subarray-with-elements-greater-than-varying-threshold">See the problem</a>
    /// </summary>
    public int ValidSubarraySize(int[] nums, int threshold)
    {
        Stack<int> increasing = new();

        for (int i = 0; i <= nums.Length; i++)
        {
            while (increasing.Count > 0 && (i == nums.Length || nums[increasing.Peek()] >= nums[i]))
            {
                int minimum = nums[increasing.Pop()];
                int left = increasing.Count == 0 ? -1 : increasing.Peek();
                int length = i - left - 1;

                // The popped value is the minimum across this entire interval.
                if ((long)minimum * length > threshold)
                {
                    return length;
                }
            }

            if (i < nums.Length)
            {
                increasing.Push(i);
            }
        }

        return -1;
    }
}
