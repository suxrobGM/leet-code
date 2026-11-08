namespace LeetCode.Solutions;

public class Solution2348
{
    /// <summary>
    /// 2348. Number of Zero-Filled Subarrays - Medium
    /// <a href="https://leetcode.com/problems/number-of-zero-filled-subarrays">See the problem</a>
    /// </summary>
    public long ZeroFilledSubarray(int[] nums)
    {
        long count = 0;
        long consecutiveZeros = 0;

        foreach (int num in nums)
        {
            consecutiveZeros = num == 0 ? consecutiveZeros + 1 : 0;
            // Each trailing zero starts one more zero-filled subarray ending here.
            count += consecutiveZeros;
        }

        return count;
    }
}
