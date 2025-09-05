using System.Text;

namespace LeetCode.Solutions;

public class Solution1800
{
    /// <summary>
    /// 1800. Maximum Ascending Subarray Sum - Easy
    /// <a href="https://leetcode.com/problems/maximum-ascending-subarray-sum">See the problem</a>
    /// </summary>
    public int MaxAscendingSum(int[] nums)
    {
        int maxSum = 0;
        int currentSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0 || nums[i] > nums[i - 1])
            {
                currentSum += nums[i];
            }
            else
            {
                maxSum = Math.Max(maxSum, currentSum);
                currentSum = nums[i];
            }
        }

        maxSum = Math.Max(maxSum, currentSum);
        return maxSum;
    }
}

