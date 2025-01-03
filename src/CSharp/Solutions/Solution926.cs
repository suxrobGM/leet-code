using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution926
{
    /// <summary>
    /// 926. Flip String to Monotone Increasing - Medium
    /// <a href="https://leetcode.com/problems/flip-string-to-monotone-increasing">See the problem</a>
    /// </summary>
    public int MinFlipsMonoIncr(string s)
    {
        int n = s.Length;
        int[] dp = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            dp[i + 1] = dp[i] + (s[i] == '1' ? 1 : 0);
        }

        int result = int.MaxValue;
        for (int i = 0; i <= n; i++)
        {
            result = Math.Min(result, dp[i] + n - i - (dp[n] - dp[i]));
        }

        return result;
    }
}
