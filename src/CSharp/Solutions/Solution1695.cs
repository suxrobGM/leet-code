using System.Text;


namespace LeetCode.Solutions;

public class Solution1695
{
    /// <summary>
    /// 1695. Maximum Erasure Value - Medium
    /// <a href="https://leetcode.com/problems/maximum-erasure-value">See the problem</a>
    /// </summary>
    public int MaximumErasureValue(int[] nums)
    {
        int maxSum = 0;
        int currentSum = 0;
        var seen = new HashSet<int>();
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            while (seen.Contains(nums[right]))
            {
                seen.Remove(nums[left]);
                currentSum -= nums[left];
                left++;
            }

            seen.Add(nums[right]);
            currentSum += nums[right];
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }
}
