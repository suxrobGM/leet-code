namespace LeetCode.Solutions;

public class Solution279
{
    /// <summary>
    /// 279. Perfect Squares - Medium
    /// <a href="https://leetcode.com/problems/perfect-squares">See the problem</a>
    /// </summary>
    public int NumSquares(int n)
    {
        var dp = new int[n + 1];
        for (var i = 1; i <= n; i++)
        {
            dp[i] = i;
            for (var j = 1; j * j <= i; j++)
            {
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
            }
        }

        return dp[n];
    }
}
