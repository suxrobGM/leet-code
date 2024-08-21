namespace LeetCode.Solutions;

public class Solution486
{
    /// <summary>
    /// 486. Predict the Winner - Medium
    /// <a href="https://leetcode.com/problems/predict-the-winner">See the problem</a>
    /// </summary>
    public bool PredictTheWinner(int[] nums)
    {
        var n = nums.Length;
        var dp = new int[n, n];

        for (var i = 0; i < n; i++)
        {
            dp[i, i] = nums[i];
        }

        for (var len = 1; len < n; len++)
        {
            for (var i = 0; i < n - len; i++)
            {
                var j = i + len;
                dp[i, j] = Math.Max(nums[i] - dp[i + 1, j], nums[j] - dp[i, j - 1]);
            }
        }

        return dp[0, n - 1] >= 0;
    }
}
