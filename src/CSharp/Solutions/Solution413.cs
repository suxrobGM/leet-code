namespace LeetCode.Solutions;

public class Solution413
{
    /// <summary>
    /// 413. Arithmetic Slices - Medium
    /// <a href="https://leetcode.com/problems/arithmetic-slices">See the problem</a>
    /// </summary>
    public int NumberOfArithmeticSlices(int[] nums)
    {
        var n = nums.Length;
        if (n < 3)
        {
            return 0;
        }

        var dp = new int[n];
        var result = 0;

        for (var i = 2; i < n; i++)
        {
            if (nums[i] - nums[i - 1] == nums[i - 1] - nums[i - 2])
            {
                dp[i] = dp[i - 1] + 1;
                result += dp[i];
            }
        }

        return result;
    }
}
