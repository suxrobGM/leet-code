using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1489
{
    /// <summary>
    /// 1489. Find Critical and Pseudo-Critical Edges in Minimum Spanning Tree - Hard
    /// <a href="https://leetcode.com/problems/find-critical-and-pseudo-critical-edges-in-minimum-spanning-tree">See the problem</a>
    /// </summary>
    public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
    {
        // Add original indices to edges
        int m = edges.Length;
        for (int i = 0; i < m; i++)
        {
            Array.Resize(ref edges[i], 4);
            edges[i][3] = i;
        }

        // Sort edges by weight
        Array.Sort(edges, (a, b) => a[2].CompareTo(b[2]));

        int baseWeight = Kruskal(n, edges, null, null);

        var critical = new List<int>();
        var pseudoCritical = new List<int>();

        for (int i = 0; i < m; i++)
        {
            // Check if critical
            if (Kruskal(n, edges, i, null) > baseWeight)
                critical.Add(edges[i][3]);
            else if (Kruskal(n, edges, null, i) == baseWeight)
                pseudoCritical.Add(edges[i][3]);
        }

        return new List<IList<int>> { critical, pseudoCritical };
    }

    // Kruskal with optional skip or force edge
    private int Kruskal(int n, int[][] edges, int? skip, int? force)
    {
        var uf = new UnionFind(n);
        int weight = 0;

        if (force.HasValue)
        {
            var e = edges[force.Value];
            if (uf.Union(e[0], e[1]))
                weight += e[2];
        }

        for (int i = 0; i < edges.Length; i++)
        {
            if (i == skip) continue;
            var e = edges[i];
            if (uf.Union(e[0], e[1]))
                weight += e[2];
        }

        return uf.Count == 1 ? weight : int.MaxValue;
    }

    // Union-Find (Disjoint Set Union)
    private class UnionFind
    {
        int[] parent, rank;
        public int Count { get; private set; }

        public UnionFind(int size)
        {
            parent = new int[size];
            rank = new int[size];
            Count = size;
            for (int i = 0; i < size; i++)
                parent[i] = i;
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }

        public bool Union(int x, int y)
        {
            int px = Find(x), py = Find(y);
            if (px == py) return false;
            if (rank[px] < rank[py])
                parent[px] = py;
            else if (rank[px] > rank[py])
                parent[py] = px;
            else
            {
                parent[py] = px;
                rank[px]++;
            }
            Count--;
            return true;
        }
    }
}
