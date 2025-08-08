using System.Text;


namespace LeetCode.Solutions;

public class Solution1697
{
    /// <summary>
    /// 1697. Checking Existence of Edge Length Limited Paths - Hard
    /// <a href="https://leetcode.com/problems/checking-existence-of-edge-length-limited-paths">See the problem</a>
    /// </summary>
    public bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
    {
        // Sort edges by weight
        Array.Sort(edgeList, (a, b) => a[2].CompareTo(b[2]));

        int m = queries.Length;
        // queriesExt: [p, q, limit, originalIndex]
        var queriesExt = new int[m][];
        for (int i = 0; i < m; i++)
        {
            queriesExt[i] = new int[] { queries[i][0], queries[i][1], queries[i][2], i };
        }
        Array.Sort(queriesExt, (a, b) => a[2].CompareTo(b[2]));

        var dsu = new DSU(n);
        var ans = new bool[m];
        int e = 0;

        // Process queries in increasing limit, union all edges with weight < limit
        for (int i = 0; i < m; i++)
        {
            int p = queriesExt[i][0];
            int q = queriesExt[i][1];
            int limit = queriesExt[i][2];
            int idx = queriesExt[i][3];

            while (e < edgeList.Length && edgeList[e][2] < limit)
            {
                dsu.Union(edgeList[e][0], edgeList[e][1]);
                e++;
            }

            ans[idx] = dsu.Find(p) == dsu.Find(q);
        }

        return ans;
    }

    private class DSU
    {
        private int[] parent;
        private int[] size;

        public DSU(int n)
        {
            parent = new int[n];
            size = new int[n];
            for (int i = 0; i < n; i++) { parent[i] = i; size[i] = 1; }
        }

        public int Find(int x)
        {
            while (x != parent[x])
            {
                parent[x] = parent[parent[x]]; // path halving
                x = parent[x];
            }
            return x;
        }

        public void Union(int a, int b)
        {
            int ra = Find(a), rb = Find(b);
            if (ra == rb) return;
            if (size[ra] < size[rb]) { var t = ra; ra = rb; rb = t; }
            parent[rb] = ra;
            size[ra] += size[rb];
        }
    }
}
