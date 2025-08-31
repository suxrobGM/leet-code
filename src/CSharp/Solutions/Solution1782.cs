using System.Text;

namespace LeetCode.Solutions;

public class Solution1782
{
    /// <summary>
    /// 1782. Count Pairs Of Nodes - Hard
    /// <a href="https://leetcode.com/problems/count-pairs-of-nodes">See the problem</a>
    /// </summary>
    public int[] CountPairs(int n, int[][] edges, int[] queries)
    {
        int[] degree = new int[n + 1];
        Dictionary<(int, int), int> edgeCount = new();

        // Build degrees and multiplicity counts
        foreach (var e in edges)
        {
            int u = e[0], v = e[1];
            degree[u]++;
            degree[v]++;
            if (u > v) (u, v) = (v, u);
            edgeCount[(u, v)] = edgeCount.GetValueOrDefault((u, v), 0) + 1;
        }

        // Sorted degrees
        int[] sorted = degree[1..];
        Array.Sort(sorted);

        int[] ans = new int[queries.Length];

        for (int qi = 0; qi < queries.Length; qi++)
        {
            int q = queries[qi];

            long count = 0;
            int l = 0, r = n - 1;

            // Two pointers: count pairs deg[l] + deg[r] > q
            while (l < r)
            {
                if (sorted[l] + sorted[r] > q)
                {
                    count += r - l;
                    r--;
                }
                else
                {
                    l++;
                }
            }

            // Fix overcount from multi-edges
            foreach (var kv in edgeCount)
            {
                int u = kv.Key.Item1, v = kv.Key.Item2;
                int c = kv.Value;
                if (degree[u] + degree[v] > q && degree[u] + degree[v] - c <= q)
                {
                    count--;
                }
            }

            ans[qi] = (int)count;
        }

        return ans;
    }
}
