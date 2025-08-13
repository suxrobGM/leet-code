using System.Text;


namespace LeetCode.Solutions;

public class Solution1719
{
    /// <summary>
    /// 1719. Number Of Ways To Reconstruct A Tree - Hard
    /// <a href="https://leetcode.com/problems/number-of-ways-to-reconstruct-a-tree">See the problem</a>
    /// </summary>
    public int CheckWays(int[][] pairs)
    {
        // 1) Collect nodes and build adjacency (neighbors = comparable nodes)
        var nodes = new HashSet<int>();
        foreach (var e in pairs)
        {
            nodes.Add(e[0]);
            nodes.Add(e[1]);
        }
        int n = nodes.Count;
        var adj = new Dictionary<int, HashSet<int>>(n);
        foreach (int v in nodes) adj[v] = new HashSet<int>();
        foreach (var e in pairs)
        {
            int x = e[0], y = e[1];
            adj[x].Add(y);
            adj[y].Add(x);
        }

        // 2) Root must be connected to all others (degree n-1)
        int root = -1;
        foreach (var v in nodes)
        {
            if (adj[v].Count == n - 1) { root = v; break; }
        }
        if (root == -1) return 0;

        // 3) Sort nodes by degree descending to ease parent selection
        var order = new List<int>(nodes);
        order.Sort((a, b) => adj[b].Count.CompareTo(adj[a].Count));

        int ways = 1;

        // 4) For each non-root, pick the parent and validate subset relation
        foreach (int u in order)
        {
            if (u == root) continue;

            int degU = adj[u].Count;
            int parent = -1;
            int bestDeg = int.MaxValue;

            // parent must be a neighbor with minimal degree >= degU
            foreach (int v in adj[u])
            {
                int degV = adj[v].Count;
                if (degV >= degU && degV < bestDeg)
                {
                    bestDeg = degV;
                    parent = v;
                }
            }
            if (parent == -1) return 0;

            // Validate: neighbors(u) \ {parent} ⊆ neighbors(parent)
            foreach (int w in adj[u])
            {
                if (w == parent) continue;
                if (!adj[parent].Contains(w)) return 0;
            }

            // If deg(parent) == deg(u), ambiguity exists
            if (bestDeg == degU) ways = 2;
        }

        return ways;
    }
}
