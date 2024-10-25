namespace LeetCode.Solutions;

public class Solution689
{
    /// <summary>
    /// 689. Maximum Sum of 3 Non-Overlapping Subarrays - Hard
    /// <a href="https://leetcode.com/problems/maximum-sum-of-3-non-overlapping-subarrays">See the problem</a>
    /// </summary>
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        var n = nums.Length;
        var sum = new int[n + 1];
        var left = new int[n];
        var right = new int[n];
        var result = new int[3];

        for (var i = 0; i < n; i++)
        {
            sum[i + 1] = sum[i] + nums[i];
        }

        var total = sum[k] - sum[0];
        for (var i = k; i < n; i++)
        {
            var current = sum[i + 1] - sum[i + 1 - k];
            if (current > total)
            {
                left[i] = i + 1 - k;
                total = current;
            }
            else
            {
                left[i] = left[i - 1];
            }
        }

        total = sum[n] - sum[n - k];
        right[n - k] = n - k;
        for (var i = n - k - 1; i >= 0; i--)
        {
            var current = sum[i + k] - sum[i];
            if (current >= total)
            {
                right[i] = i;
                total = current;
            }
            else
            {
                right[i] = right[i + 1];
            }
        }

        total = 0;
        for (var i = k; i <= n - 2 * k; i++)
        {
            var l = left[i - 1];
            var r = right[i + k];
            var current = sum[l + k] - sum[l] + sum[i + k] - sum[i] + sum[r + k] - sum[r];
            if (current > total)
            {
                total = current;
                result[0] = l;
                result[1] = i;
                result[2] = r;
            }
        }

        return result;
    }
}
