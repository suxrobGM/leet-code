using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1579
{
    /// <summary>
    /// 1579. Remove Max Number of Edges to Keep Graph Fully Traversable - Hard
    /// <a href="https://leetcode.com/problems/remove-max-number-of-edges-to-keep-graph-fully-traversable">See the problem</a>
    /// </summary>
    public int MaxNumEdgesToRemove(int n, int[][] edges)
    {
        // Sort edges so that type 3 edges are processed first
        Array.Sort(edges, (a, b) => b[0] - a[0]);

        var dsuA = new DisjointSetUnion(n);
        var dsuB = new DisjointSetUnion(n);
        int edgesUsed = 0;

        foreach (var edge in edges)
        {
            int type = edge[0];
            int u = edge[1] - 1; // Convert to 0-based index
            int v = edge[2] - 1; // Convert to 0-based index

            if (type == 3)
            {
                // Type 3 edge, can be used by both Alice and Bob
                if (dsuA.Union(u, v))
                {
                    dsuB.Union(u, v);
                    edgesUsed++;
                }
            }
            else if (type == 1)
            {
                // Type 1 edge, can be used by Alice only
                if (dsuA.Union(u, v))
                {
                    edgesUsed++;
                }
            }
            else if (type == 2)
            {
                // Type 2 edge, can be used by Bob only
                if (dsuB.Union(u, v))
                {
                    edgesUsed++;
                }
            }
        }

        // Check if both Alice and Bob can traverse the entire graph
        if (dsuA.GetConnectedComponents() > 1 || dsuB.GetConnectedComponents() > 1)
        {
            return -1; // Not fully traversable
        }

        return edges.Length - edgesUsed; // Maximum number of edges that can be removed
    }

    private class DisjointSetUnion
    {
        private int[] parent;
        private int[] rank;
        private int connectedComponents;

        public DisjointSetUnion(int size)
        {
            parent = new int[size];
            rank = new int[size];
            connectedComponents = size;

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
                parent[u] = Find(parent[u]); // Path compression
            }
            return parent[u];
        }

        public bool Union(int u, int v)
        {
            int rootU = Find(u);
            int rootV = Find(v);

            if (rootU == rootV)
            {
                return false; // Already in the same set
            }

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

            connectedComponents--;
            return true;
        }

        public int GetConnectedComponents()
        {
            return connectedComponents;
        }
    }
}
