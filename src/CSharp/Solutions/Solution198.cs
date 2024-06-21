namespace LeetCode.Solutions;

public class Solution198
{
    /// <summary>
    /// 198. House Robber - Medium
    /// <a href="https://leetcode.com/problems/house-robber">See the problem</a>
    /// </summary>
    public int Rob(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }

        var dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (var i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return dp[nums.Length - 1];
    }
}
