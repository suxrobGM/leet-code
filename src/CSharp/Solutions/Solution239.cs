using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution239
{
    /// <summary>
    /// 239. Sliding Window Maximum - Hard
    /// <a href="https://leetcode.com/problems/sliding-window-maximum">See the problem</a>
    /// </summary>
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var n = nums.Length;
        if (n * k == 0)
        {
            return [];
        }

        if (k == 1)
        {
            return nums;
        }

        var left = new int[n];
        left[0] = nums[0];
        var right = new int[n];
        right[n - 1] = nums[n - 1];

        for (var i = 1; i < n; i++)
        {
            if (i % k == 0)
            {
                left[i] = nums[i];
            }
            else
            {
                left[i] = Math.Max(left[i - 1], nums[i]);
            }

            var j = n - i - 1;
            if ((j + 1) % k == 0)
            {
                right[j] = nums[j];
            }
            else
            {
                right[j] = Math.Max(right[j + 1], nums[j]);
            }
        }

        var output = new int[n - k + 1];
        for (var i = 0; i < n - k + 1; i++)
        {
            output[i] = Math.Max(right[i], left[i + k - 1]);
        }

        return output;
    }
}
