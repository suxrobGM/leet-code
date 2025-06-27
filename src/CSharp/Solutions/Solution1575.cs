using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1575
{
    private const int MOD = 1_000_000_007;
    private int[][] memo;
    private int[] locations;
    private int finish;
    private int n;

    /// <summary>
    /// 1575. Count All Possible Routes - Hard
    /// <a href="https://leetcode.com/problems/count-all-possible-routes">See the problem</a>
    /// </summary>
    public int CountRoutes(int[] locations, int start, int finish, int fuel)
    {
        this.locations = locations;
        this.finish = finish;
        this.n = locations.Length;
        memo = new int[n][];
        for (int i = 0; i < n; i++)
        {
            memo[i] = new int[fuel + 1];
            Array.Fill(memo[i], -1);
        }

        return Dfs(start, fuel);
    }

    private int Dfs(int current, int fuelLeft)
    {
        if (fuelLeft < 0) return 0;

        if (memo[current][fuelLeft] != -1)
            return memo[current][fuelLeft];

        long totalWays = (current == finish) ? 1 : 0;

        for (int next = 0; next < n; next++)
        {
            if (next == current) continue;

            int cost = Math.Abs(locations[current] - locations[next]);
            if (fuelLeft >= cost)
            {
                totalWays += Dfs(next, fuelLeft - cost);
                totalWays %= MOD;
            }
        }

        memo[current][fuelLeft] = (int)totalWays;
        return memo[current][fuelLeft];
    }
}
