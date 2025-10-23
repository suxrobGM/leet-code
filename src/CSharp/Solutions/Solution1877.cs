using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1877
{
    /// <summary>
    /// 1877. Minimize Maximum Pair Sum in Array - Medium
    /// <a href="https://leetcode.com/problems/minimize-maximum-pair-sum-in-array">See the problem</a>
    /// </summary>
    public int MinPairSum(int[] nums)
    {
        Array.Sort(nums);
        int left = 0;
        int right = nums.Length - 1;
        int maxPairSum = 0;

        while (left < right)
        {
            int pairSum = nums[left] + nums[right];
            maxPairSum = Math.Max(maxPairSum, pairSum);
            left++;
            right--;
        }

        return maxPairSum;
    }
}
