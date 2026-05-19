namespace LeetCode.Solutions;

public class Solution2140
{
    /// <summary>
    /// 2140. Solving Questions With Brainpower - Medium
    /// <a href="https://leetcode.com/problems/solving-questions-with-brainpower">See the problem</a>
    /// </summary>
    public long MostPoints(int[][] questions)
    {
        int n = questions.Length;
        long[] dp = new long[n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            int points = questions[i][0];
            int brainpower = questions[i][1];
            dp[i] = Math.Max(points + (i + brainpower + 1 < n ? dp[i + brainpower + 1] : 0), dp[i + 1]);
        }
        return dp[0];
    }
}
