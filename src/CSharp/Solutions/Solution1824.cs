using System.Text;

namespace LeetCode.Solutions;

public class Solution1824
{
    /// <summary>
    /// 1824. Minimum Sideway Jumps - Medium
    /// <a href="https://leetcode.com/problems/minimum-sideway-jumps">See the problem</a>
    /// </summary>
    public int MinSideJumps(int[] obstacles)
    {
        const int INF = 1_000_000_000;
        int n = obstacles.Length - 1; // points 0..n

        // dp[lane]: min side jumps to be at current point on that lane
        int[] dp = new int[4]; // 1..3 used
        dp[1] = 1;
        dp[2] = 0;
        dp[3] = 1;

        for (int i = 1; i <= n; i++)
        {
            int obs = obstacles[i];
            // Block the lane with obstacle at point i
            if (obs != 0) dp[obs] = INF;

            // Relax by side jumps at the same point i
            int m = Math.Min(dp[1], Math.Min(dp[2], dp[3]));
            for (int l = 1; l <= 3; l++)
            {
                if (l == obs) continue;           // can't be on blocked lane
                dp[l] = Math.Min(dp[l], m + 1);   // side jump from best lane if better
            }
        }

        return Math.Min(dp[1], Math.Min(dp[2], dp[3]));
    }
}
