using System.Text;


namespace LeetCode.Solutions;

public class Solution1685
{
    /// <summary>
    /// 1685. Sum of Absolute Differences in a Sorted Array - Medium
    /// <a href="https://leetcode.com/problems/sum-of-absolute-differences-in-a-sorted-array">See the problem</a>
    /// </summary>
    public int[] GetSumAbsoluteDifferences(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];
        int[] prefixSum = new int[n + 1];

        // Calculate prefix sums
        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        // Calculate the result for each index
        for (int i = 0; i < n; i++)
        {
            int leftSum = nums[i] * i - prefixSum[i];
            int rightSum = (prefixSum[n] - prefixSum[i + 1]) - nums[i] * (n - i - 1);
            result[i] = leftSum + rightSum;
        }

        return result;
    }
}
