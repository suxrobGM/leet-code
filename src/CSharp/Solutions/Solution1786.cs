using System.Text;

namespace LeetCode.Solutions;

public class Solution1786
{
    private const int MOD = 1_000_000_007;

    /// <summary>
    /// 1786. Number of Restricted Paths From First to Last Node - Medium
    /// <a href="https://leetcode.com/problems/number-of-restricted-paths-from-first-to-last-node">See the problem</a>
    /// </summary>
    public int CountRestrictedPaths(int n, int[][] edges)
    {
        var graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++) graph[i] = new List<(int, int)>();

        foreach (var e in edges)
        {
            int u = e[0], v = e[1], w = e[2];
            graph[u].Add((v, w));
            graph[v].Add((u, w));
        }

        // Step 1: Dijkstra from node n
        var dist = new long[n + 1];
        Array.Fill(dist, long.MaxValue);
        dist[n] = 0;

        var pq = new PriorityQueue<(int node, long d), long>();
        pq.Enqueue((n, 0), 0);

        while (pq.Count > 0)
        {
            var (u, d) = pq.Dequeue();
            if (d > dist[u]) continue;

            foreach (var (v, w) in graph[u])
            {
                long nd = d + w;
                if (nd < dist[v])
                {
                    dist[v] = nd;
                    pq.Enqueue((v, nd), nd);
                }
            }
        }

        // Step 2: DFS + Memo
        var memo = new int[n + 1];
        Array.Fill(memo, -1);

        return Dfs(1);

        int Dfs(int u)
        {
            if (u == n) return 1;
            if (memo[u] != -1) return memo[u];

            long ways = 0;
            foreach (var (v, _) in graph[u])
            {
                if (dist[u] > dist[v])
                {
                    ways += Dfs(v);
                    ways %= MOD;
                }
            }

            memo[u] = (int)ways;
            return memo[u];
        }
    }
}

