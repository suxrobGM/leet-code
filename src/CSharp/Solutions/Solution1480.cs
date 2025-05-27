using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1480
{
    /// <summary>
    /// 1480. Running Sum of 1d Array - Easy
    /// <a href="https://leetcode.com/problems/running-sum-of-1d-array">See the problem</a>
    /// </summary>
    public int[] RunningSum(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];
        result[0] = nums[0];

        for (int i = 1; i < n; i++)
        {
            result[i] = result[i - 1] + nums[i];
        }

        return result;
    }
}
