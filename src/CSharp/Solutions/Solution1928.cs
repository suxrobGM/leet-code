using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1928
{
    /// <summary>
    /// 1928. Minimum Cost to Reach Destination in Time - Hard
    /// <a href="https://leetcode.com/problems/minimum-cost-to-reach-destination-in-time">See the problem</a>
    /// </summary>
    public int MinCost(int maxTime, int[][] edges, int[] passingFees)
    {
        int n = passingFees.Length;
        const int INF = int.MaxValue / 2;

        // dp[t, i] = min cost to reach city i in exactly t minutes
        int[,] dp = new int[maxTime + 1, n];

        // Initialize dp with INF
        for (int t = 0; t <= maxTime; t++)
        {
            for (int i = 0; i < n; i++)
            {
                dp[t, i] = INF;
            }
        }

        // Start at city 0 at time 0
        dp[0, 0] = passingFees[0];

        // For each time from 1 to maxTime, relax all edges
        for (int t = 1; t <= maxTime; t++)
        {
            foreach (var e in edges)
            {
                int u = e[0];
                int v = e[1];
                int w = e[2]; // travel time

                if (t >= w)
                {
                    int prevTime = t - w;

                    // From u to v
                    if (dp[prevTime, u] != INF)
                    {
                        int cost = dp[prevTime, u] + passingFees[v];
                        if (cost < dp[t, v])
                            dp[t, v] = cost;
                    }

                    // From v to u (roads are bidirectional)
                    if (dp[prevTime, v] != INF)
                    {
                        int cost = dp[prevTime, v] + passingFees[u];
                        if (cost < dp[t, u])
                            dp[t, u] = cost;
                    }
                }
            }
        }

        // Find the minimum cost to reach city n-1 within maxTime
        int ans = INF;
        for (int t = 0; t <= maxTime; t++)
        {
            if (dp[t, n - 1] < ans)
                ans = dp[t, n - 1];
        }

        return ans == INF ? -1 : ans;
    }
}
