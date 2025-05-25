using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1473
{
    private const int INF = int.MaxValue / 2;
    private int[,,] memo;
    private int[] houses;
    private int[][] cost;
    private int m, n, target;

    /// <summary>
    /// 1473. Paint House III - Hard
    /// <a href="https://leetcode.com/problems/design-browser-history">See the problem</a>
    /// </summary>
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
        this.houses = houses;
        this.cost = cost;
        this.m = m;
        this.n = n;
        this.target = target;

        // Memoization array: house index, remaining neighborhoods, previous color
        memo = new int[m, target + 1, n + 1];
        for (int i = 0; i < m; i++)
            for (int j = 0; j <= target; j++)
                for (int k = 0; k <= n; k++)
                    memo[i, j, k] = -1;

        int res = Dfs(0, target, 0);
        return res == INF ? -1 : res;
    }

    private int Dfs(int idx, int t, int prevColor)
    {
        if (t < 0) return INF;
        if (idx == m) return t == 0 ? 0 : INF;
        if (memo[idx, t, prevColor] != -1) return memo[idx, t, prevColor];

        int minCost = INF;

        if (houses[idx] != 0)
        {
            // Already painted
            int newT = (houses[idx] != prevColor) ? t - 1 : t;
            minCost = Dfs(idx + 1, newT, houses[idx]);
        }
        else
        {
            // Not painted yet, try all colors
            for (int color = 1; color <= n; color++)
            {
                int newT = (color != prevColor) ? t - 1 : t;
                int c = cost[idx][color - 1];
                int totalCost = Dfs(idx + 1, newT, color);
                if (totalCost != INF)
                    minCost = Math.Min(minCost, c + totalCost);
            }
        }

        return memo[idx, t, prevColor] = minCost;
    }
}
