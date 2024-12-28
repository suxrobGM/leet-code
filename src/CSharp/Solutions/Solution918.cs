using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution918
{
    /// <summary>
    /// 918. Maximum Sum Circular Subarray - Medium
    /// <a href="https://leetcode.com/problems/maximum-sum-circular-subarray">See the problem</a>
    /// </summary>
    public int MaxSubarraySumCircular(int[] nums)
    {
        var maxSum = int.MinValue;
        var minSum = int.MaxValue;
        var currentMax = 0;
        var currentMin = 0;
        var totalSum = 0;

        foreach (var num in nums)
        {
            currentMax = Math.Max(currentMax + num, num);
            maxSum = Math.Max(maxSum, currentMax);

            currentMin = Math.Min(currentMin + num, num);
            minSum = Math.Min(minSum, currentMin);

            totalSum += num;
        }

        return maxSum > 0 ? Math.Max(maxSum, totalSum - minSum) : maxSum;
    }
}
