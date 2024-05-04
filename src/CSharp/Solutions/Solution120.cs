namespace LeetCode.Solutions;

public class Solution120
{
    /// <summary>
    /// 120. Triangle - Medium
    /// <a href="https://leetcode.com/problems/triangle">See the problem</a>
    /// </summary>
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var n = triangle.Count;
        var dp = new int[n + 1];

        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = 0; j <= i; j++)
            {
                dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];
            }
        }

        return dp[0];
    }
}
