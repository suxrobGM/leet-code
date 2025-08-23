using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1749
{
    /// <summary>
    /// 1749. Maximum Absolute Sum of Any Subarray - Medium
    /// <a href="https://leetcode.com/problems/maximum-absolute-sum-of-any-subarray">See the problem</a>
    /// </summary>
    public int MaxAbsoluteSum(int[] nums)
    {
        int maxSum = 0;
        int minSum = 0;
        int currentMax = 0;
        int currentMin = 0;

        foreach (int num in nums)
        {
            currentMax += num;
            currentMin += num;

            maxSum = Math.Max(maxSum, currentMax);
            minSum = Math.Min(minSum, currentMin);

            currentMax = Math.Max(currentMax, 0);
            currentMin = Math.Min(currentMin, 0);
        }

        return Math.Max(maxSum, -minSum);
    }
}

