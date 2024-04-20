namespace LeetCode.Solutions;

public class Solution887
{
    /// <summary>
    /// 887. Super Egg Drop - Hard
    /// <a href="https://leetcode.com/problems/super-egg-drop">See the problem</a>
    /// </summary>
    public int SuperEggDrop(int k, int n)
    {
        var dp = new int[k + 1, n + 1];
        var m = 0; // Number of moves

        while (dp[k, m] < n)
        {
            m++;
            for (var i = 1; i <= k; i++)
            {
                dp[i, m] = dp[i, m - 1] + dp[i - 1, m - 1] + 1;
            }
        }

        return m;
    }
}
