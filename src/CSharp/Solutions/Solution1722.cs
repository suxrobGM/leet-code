using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1722
{
    /// <summary>
    /// 1721. Swapping Nodes in a Linked List - Medium
    /// <a href="https://leetcode.com/problems/swapping-nodes-in-a-linked-list">See the problem</a>
    /// </summary>
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        int n = source.Length;
        var dsu = new DSU(n);

        // 1) Build components via allowed swaps
        foreach (var e in allowedSwaps)
            dsu.Union(e[0], e[1]);

        // 2) For each component, count frequency of source values
        var compFreq = new Dictionary<int, Dictionary<int, int>>();
        for (int i = 0; i < n; i++)
        {
            int r = dsu.Find(i);
            if (!compFreq.TryGetValue(r, out var dict))
            {
                dict = new Dictionary<int, int>();
                compFreq[r] = dict;
            }
            dict.TryGetValue(source[i], out int c);
            dict[source[i]] = c + 1;
        }

        // 3) Try to match target values from the component’s multiset
        int mismatches = 0;
        for (int i = 0; i < n; i++)
        {
            int r = dsu.Find(i);
            var dict = compFreq[r];
            if (dict.TryGetValue(target[i], out int c) && c > 0)
            {
                dict[target[i]] = c - 1; // matched one
            }
            else
            {
                mismatches++;             // cannot match inside this component
            }
        }

        return mismatches;
    }

    private class DSU
    {
        private int[] parent;
        private int[] rank;

        public DSU(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++) parent[i] = i;
        }

        public int Find(int x)
        {
            if (parent[x] != x) parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                    parent[rootY] = rootX;
                else if (rank[rootX] < rank[rootY])
                    parent[rootX] = rootY;
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }
    }
}
