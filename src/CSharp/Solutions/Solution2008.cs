namespace LeetCode.Solutions;

public class Solution2008
{
    /// <summary>
    /// 2008. Maximum Earnings From Taxi - Medium
    /// <a href="https://leetcode.com/problems/maximum-earnings-from-taxi">See the problem</a>
    /// </summary>
    public long MaxTaxiEarnings(int n, int[][] rides)
    {
        // Group rides by their start point for efficient lookup
        var ridesByStart = new Dictionary<int, List<int[]>>();
        foreach (var ride in rides)
        {
            int start = ride[0];
            if (!ridesByStart.ContainsKey(start))
                ridesByStart[start] = new List<int[]>();
            ridesByStart[start].Add(ride);
        }

        // dp[i] = maximum earnings starting from point i
        long[] dp = new long[n + 2];

        // Process from right to left
        for (int i = n; i >= 1; i--)
        {
            // Option 1: Don't pick anyone at point i, move forward
            dp[i] = dp[i + 1];

            // Option 2: Pick up a passenger starting at point i
            if (ridesByStart.TryGetValue(i, out var ridesAtI))
            {
                foreach (var ride in ridesAtI)
                {
                    int end = ride[1], tip = ride[2];
                    long earnings = end - i + tip + dp[end];
                    dp[i] = Math.Max(dp[i], earnings);
                }
            }
        }

        return dp[1];
    }
}
