using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1330
{
    /// <summary>
    /// 1330. Reverse Subarray To Maximize Array Value - Hard
    /// <a href="https://leetcode.com/problems/reverse-subarray-to-maximize-array-value">See the problem</a>
    /// </summary>
    public int MaxValueAfterReverse(int[] nums)
    {
        int n = nums.Length;
        int total = 0;
        for (int i = 0; i < n - 1; i++)
            total += Math.Abs(nums[i] - nums[i + 1]);

        int maxGain = 0;

        // Case 1: Reverse [0..i]
        for (int i = 1; i < n - 1; i++)
        {
            int gain = Math.Abs(nums[0] - nums[i + 1]) - Math.Abs(nums[i] - nums[i + 1]);
            maxGain = Math.Max(maxGain, gain);
        }

        // Case 2: Reverse [i..n-1]
        for (int i = 1; i < n - 1; i++)
        {
            int gain = Math.Abs(nums[n - 1] - nums[i - 1]) - Math.Abs(nums[i] - nums[i - 1]);
            maxGain = Math.Max(maxGain, gain);
        }

        // Case 3: Reverse [i..j] in middle
        int min2 = int.MaxValue, max2 = int.MinValue;
        for (int i = 0; i < n - 1; i++)
        {
            int a = nums[i];
            int b = nums[i + 1];
            min2 = Math.Min(min2, Math.Max(a, b));
            max2 = Math.Max(max2, Math.Min(a, b));
        }
        maxGain = Math.Max(maxGain, 2 * (max2 - min2));

        return total + maxGain;
    }
}
