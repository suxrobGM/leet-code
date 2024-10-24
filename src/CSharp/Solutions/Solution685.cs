namespace LeetCode.Solutions;

public class Solution685
{
    /// <summary>
    /// 685. Redundant Connection II - Hard
    /// <a href="https://leetcode.com/problems/redundant-connection-ii">See the problem</a>
    /// </summary>
    public int[] FindRedundantDirectedConnection(int[][] edges)
    {
        var n = edges.Length;
        var parent = new int[n + 1];
        int[] can1 = null, can2 = null;

        // Step 1: Detect a node with two parents
        for (var i = 0; i < n; i++)
        {
            int u = edges[i][0], v = edges[i][1];
            if (parent[v] == 0)
            {
                parent[v] = u;
            }
            else
            {
                // v has two parents
                can1 = [parent[v], v]; // The first edge causing the issue
                can2 = [u, v];         // The second edge causing the issue
                // Temporarily remove can2 and continue checking
                edges[i][1] = 0; // Invalidate can2 for now
            }
        }

        // Step 2: Use Union-Find to detect a cycle
        var uf = new UnionFind(n);
        for (var i = 0; i < n; i++)
        {
            if (edges[i][1] == 0) continue; // Ignore the invalidated edge

            int u = edges[i][0], v = edges[i][1];
            if (!uf.Union(u, v))
            {
                // If we detect a cycle
                if (can1 == null)
                {
                    // No two parents issue, return the edge causing the cycle
                    return edges[i];
                }
                // If can1 and can2 exist, return can1 because removing it breaks the cycle
                return can1;
            }
        }

        // If there's no cycle but a two parents issue, return can2
        return can2;
    }

    public class UnionFind
    {
        private int[] parent;
        private int[] rank;

        public UnionFind(int size)
        {
            parent = new int[size + 1];
            rank = new int[size + 1];
            for (var i = 0; i <= size; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]); // Path compression
            }
            return parent[x];
        }

        public bool Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);
            if (rootX == rootY)
            {
                return false; // Cycle detected
            }

            if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }

            return true;
        }
    }
}
