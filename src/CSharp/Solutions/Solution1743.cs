using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1743
{
    /// <summary>
    /// 1743. Restore the Array From Adjacent Pairs - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-balls-in-a-box">See the problem</a>
    /// </summary>
    public int[] RestoreArray(int[][] adjacentPairs)
    {
        int n = adjacentPairs.Length + 1;
        var adj = new Dictionary<int, List<int>>(n);

        // Build adjacency list (each value has 1 or 2 neighbors)
        foreach (var p in adjacentPairs)
        {
            int a = p[0], b = p[1];

            if (!adj.TryGetValue(a, out var la)) { la = new List<int>(2); adj[a] = la; }
            if (!adj.TryGetValue(b, out var lb)) { lb = new List<int>(2); adj[b] = lb; }
            la.Add(b);
            lb.Add(a);
        }

        // Find one endpoint (degree 1)
        int start = 0;
        foreach (var kv in adj)
        {
            if (kv.Value.Count == 1)
            {
                start = kv.Key;
                break;
            }
        }

        var ans = new int[n];
        ans[0] = start;

        if (n == 2)
        {
            ans[1] = adj[start][0];
            return ans;
        }

        // Second element is the unique neighbor of the start
        ans[1] = adj[start][0];

        // Reconstruct by walking, avoiding the previous value
        for (int i = 2; i < n; i++)
        {
            int prev = ans[i - 2];
            int cur = ans[i - 1];
            var neighbors = adj[cur]; // size 2 except at ends
            ans[i] = (neighbors[0] == prev) ? neighbors[1] : neighbors[0];
        }

        return ans;
    }
}

