using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1584
{
    /// <summary>
    /// 1584. Min Cost to Connect All Points - Medium
    /// <a href="https://leetcode.com/problems/min-cost-to-connect-all-points">See the problem</a>
    /// </summary>
    public int MinCostConnectPoints(int[][] points)
    {
        int n = points.Length;
        var edges = new List<(int u, int v, int cost)>();

        // Create all edges with their costs
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int cost = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                edges.Add((i, j, cost));
            }
        }

        // Sort edges by cost
        edges.Sort((a, b) => a.cost.CompareTo(b.cost));

        // Union-Find structure
        var uf = new UnionFind(n);
        int totalCost = 0;

        // Kruskal's algorithm to find the minimum spanning tree
        foreach (var edge in edges)
        {
            if (uf.Union(edge.u, edge.v))
            {
                totalCost += edge.cost;
            }
        }

        return totalCost;
    }

    private class UnionFind
    {
        private int[] parent;
        private int[] rank;

        public UnionFind(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        public int Find(int u)
        {
            if (parent[u] != u)
            {
                parent[u] = Find(parent[u]);
            }
            return parent[u];
        }

        public bool Union(int u, int v)
        {
            int rootU = Find(u);
            int rootV = Find(v);
            if (rootU == rootV) return false;

            // Union by rank
            if (rank[rootU] > rank[rootV])
            {
                parent[rootV] = rootU;
            }
            else if (rank[rootU] < rank[rootV])
            {
                parent[rootU] = rootV;
            }
            else
            {
                parent[rootV] = rootU;
                rank[rootU]++;
            }
            return true;
        }
    }
}
