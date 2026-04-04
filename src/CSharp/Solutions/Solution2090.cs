namespace LeetCode.Solutions;

public class Solution2090
{
    /// <summary>
    /// 2090. K Radius Subarray Averages - Medium
    /// <a href="https://leetcode.com/problems/k-radius-subarray-averages">See the problem</a>
    /// </summary>
    public int[] GetAverages(int[] nums, int k)
    {
        var n = nums.Length;
        var result = new int[n];
        Array.Fill(result, -1);

        var window = 2 * k + 1;
        if (window > n) return result;

        long sum = 0;
        for (var i = 0; i < window; i++)
            sum += nums[i];

        result[k] = (int)(sum / window);

        for (var i = k + 1; i < n - k; i++)
        {
            sum += nums[i + k] - nums[i - k - 1];
            result[i] = (int)(sum / window);
        }

        return result;
    }
}
