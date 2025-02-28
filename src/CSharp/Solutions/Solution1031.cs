using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1031
{
    /// <summary>
    /// 1031. Maximum Sum of Two Non-Overlapping Subarrays - Medium
    /// <a href="https://leetcode.com/problems/maximum-sum-of-two-non-overlapping-subarrays</a>
    /// </summary>
    public int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen)
    {
        return Math.Max(
            MaxSubarraySum(nums, firstLen, secondLen),
            MaxSubarraySum(nums, secondLen, firstLen)
        );
    }

    private int MaxSubarraySum(int[] nums, int firstLen, int secondLen)
    {
        int n = nums.Length;
        int[] prefix = new int[n + 1];

        // Compute prefix sums
        for (int i = 0; i < n; i++)
            prefix[i + 1] = prefix[i] + nums[i];

        int maxFirst = 0, maxSum = 0;

        // Iterate through the array maintaining max sum of the first subarray
        for (int i = firstLen + secondLen; i <= n; i++)
        {
            // Max sum of firstLen-sized subarray before the current position
            maxFirst = Math.Max(maxFirst, prefix[i - secondLen] - prefix[i - secondLen - firstLen]);

            // Compute the sum of the secondLen-sized subarray at the current position
            int secondSum = prefix[i] - prefix[i - secondLen];

            // Update maxSum
            maxSum = Math.Max(maxSum, maxFirst + secondSum);
        }

        return maxSum;
    }
}
