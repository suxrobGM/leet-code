using System.Text;

namespace LeetCode.Solutions;

public class Solution1838
{
    /// <summary>
    /// 1838. Frequency of the Most Frequent Element - Medium
    /// <a href="https://leetcode.com/problems/frequency-of-the-most-frequent-element">See the problem</a>
    /// </summary>
    public int MaxFrequency(int[] nums, int k)
    {
        Array.Sort(nums);
        long sum = 0; // sum of current window
        int best = 1, l = 0;

        for (int r = 0; r < nums.Length; r++)
        {
            sum += nums[r];

            // cost to raise all nums[l..r] to nums[r]
            while ((long)nums[r] * (r - l + 1) - sum > k)
            {
                sum -= nums[l];
                l++;
            }
            best = Math.Max(best, r - l + 1);
        }
        return best;
    }
}
