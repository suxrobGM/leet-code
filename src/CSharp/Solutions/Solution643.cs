namespace LeetCode.Solutions;

public class Solution643
{
    /// <summary>
    /// 643. Maximum Average Subarray I - Easy
    /// <a href="https://leetcode.com/problems/maximum-average-subarray-i">See the problem</a>
    /// </summary>
    public double FindMaxAverage(int[] nums, int k)
    {
        var n = nums.Length;

        // Calculate the sum of the first k elements (initial window)
        var windowSum = 0d;
        for (var i = 0; i < k; i++)
        {
            windowSum += nums[i];
        }

        // Set the maximum sum as the initial window sum
        var maxSum = windowSum;

        // Slide the window from index k to the end of the array
        for (var i = k; i < n; i++)
        {
            // Update the window sum by subtracting the element that is left behind
            // and adding the new element that comes into the window
            windowSum += nums[i] - nums[i - k];

            // Track the maximum sum
            maxSum = Math.Max(maxSum, windowSum);
        }

        // Return the maximum average
        return maxSum / k;
    }
}
