namespace LeetCode.Solutions;

public class Solution2203
{
    /// <summary>
    /// 2203. Minimum Weighted Subgraph With the Required Paths - Hard
    /// <a href="https://leetcode.com/problems/minimum-weighted-subgraph-with-the-required-paths">See the problem</a>
    /// </summary>
    public long MinimumWeight(int n, int[][] edges, int src1, int src2, int dest)
    {
        var forward = BuildGraph(n, edges, reversed: false);
        var backward = BuildGraph(n, edges, reversed: true);

        var fromSrc1 = Dijkstra(n, forward, src1);
        var fromSrc2 = Dijkstra(n, forward, src2);
        var toDest = Dijkstra(n, backward, dest);

        var best = long.MaxValue;

        // Both routes have to merge at some node, and from there a single shared path runs to dest
        for (int meet = 0; meet < n; meet++)
        {
            if (fromSrc1[meet] == long.MaxValue || fromSrc2[meet] == long.MaxValue || toDest[meet] == long.MaxValue)
            {
                continue;
            }

            best = Math.Min(best, fromSrc1[meet] + fromSrc2[meet] + toDest[meet]);
        }

        return best == long.MaxValue ? -1 : best;
    }

    private static List<(int To, int Weight)>[] BuildGraph(int n, int[][] edges, bool reversed)
    {
        var graph = new List<(int To, int Weight)>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }

        foreach (var edge in edges)
        {
            var (from, to, weight) = (edge[0], edge[1], edge[2]);

            if (reversed)
            {
                (from, to) = (to, from);
            }

            graph[from].Add((to, weight));
        }

        return graph;
    }

    private static long[] Dijkstra(int n, List<(int To, int Weight)>[] graph, int source)
    {
        var dist = new long[n];
        Array.Fill(dist, long.MaxValue);
        dist[source] = 0;

        var queue = new PriorityQueue<int, long>();
        queue.Enqueue(source, 0);

        while (queue.TryDequeue(out var node, out var distance))
        {
            // Stale entry, a shorter path to this node was already settled
            if (distance > dist[node])
            {
                continue;
            }

            foreach (var (next, weight) in graph[node])
            {
                var candidate = distance + weight;

                if (candidate < dist[next])
                {
                    dist[next] = candidate;
                    queue.Enqueue(next, candidate);
                }
            }
        }

        return dist;
    }
}
