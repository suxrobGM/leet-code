using System.Text;

namespace LeetCode.Solutions;

public class Solution2302
{
    /// <summary>
    /// 2302. Count Subarrays With Score Less Than K - Hard
    /// <a href="https://leetcode.com/problems/count-subarrays-with-score-less-than-k">See the problem</a>
    /// </summary>
    public long CountSubarrays(int[] nums, long k)
    {
        long count = 0;
        long sum = 0;
        var left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (sum * (right - left + 1) >= k)
            {
                sum -= nums[left];
                left++;
            }

            count += right - left + 1;
        }

        return count;
    }
}
