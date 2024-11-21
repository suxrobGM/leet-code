using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution837
{
    /// <summary>
    /// 837. New 21 Game - Medium
    /// <a href="https://leetcode.com/problems/new-21-game">See the problem</a>
    /// </summary>
    public double New21Game(int n, int k, int maxPts)
    {
        if (k == 0 || n >= k + maxPts) return 1;

        var dp = new double[n + 1];
        dp[0] = 1;
        double sum = 1;
        double res = 0;

        for (int i = 1; i <= n; i++)
        {
            dp[i] = sum / maxPts;
            if (i < k) sum += dp[i];
            else res += dp[i];
            if (i - maxPts >= 0) sum -= dp[i - maxPts];
        }

        return res;
    }
}
