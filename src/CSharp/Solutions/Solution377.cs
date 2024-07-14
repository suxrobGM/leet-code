namespace LeetCode.Solutions;

public class Solution377
{
    /// <summary>
    /// 377. Combination Sum IV - Medium
    /// <a href="https://leetcode.com/problems/combination-sum-iv">See the problem</a>
    /// </summary>
    public int CombinationSum4(int[] nums, int target)
    {
        var dp = new int[target + 1];
        dp[0] = 1;

        for (var i = 1; i <= target; i++)
        {
            foreach (var num in nums)
            {
                if (num <= i)
                {
                    dp[i] += dp[i - num];
                }
            }
        }

        return dp[target];
    }
}
