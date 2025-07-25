using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1658
{
    /// <summary>
    /// 1658. Minimum Operations to Reduce X to Zero - Medium
    /// <a href="https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero">See the problem</a>
    /// </summary>
    public int MinOperations(int[] nums, int x)
    {
        int total = nums.Sum();
        int target = total - x;

        if (target < 0) return -1;

        int maxLength = -1;
        int currentSum = 0;
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            currentSum += nums[right];

            while (currentSum > target && left <= right)
            {
                currentSum -= nums[left];
                left++;
            }

            if (currentSum == target)
            {
                maxLength = Math.Max(maxLength, right - left + 1);
            }
        }

        return maxLength == -1 ? -1 : nums.Length - maxLength;
    }
}
