namespace LeetCode.Solutions;

public class Solution209
{
    /// <summary>
    /// 209. Minimum Size Subarray Sum
    /// <a href="https://leetcode.com/problems/minimum-size-subarray-sum">See the problem</a>
    /// </summary>
    public int MinSubArrayLen(int target, int[] nums)
    {
        var left = 0;
        var sum = 0;
        var minLen = int.MaxValue;
        
        // Sliding window
        for (var right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (sum >= target)
            {
                minLen = Math.Min(minLen, right - left + 1);
                sum -= nums[left];
                left++;
            }
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }
}
