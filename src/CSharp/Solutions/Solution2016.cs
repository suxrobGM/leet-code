namespace LeetCode.Solutions;

public class Solution2016
{
    /// <summary>
    /// 2016. Maximum Difference Between Increasing Elements - Easy
    /// <a href="https://leetcode.com/problems/maximum-difference-between-increasing-elements">See the problem</a>
    /// </summary>
    public int MaximumDifference(int[] nums)
    {
        int minVal = nums[0];
        int maxDiff = -1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > minVal)
            {
                maxDiff = Math.Max(maxDiff, nums[i] - minVal);
            }
            else
            {
                minVal = nums[i];
            }
        }

        return maxDiff;
    }
}
