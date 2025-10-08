using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1857
{
    /// <summary>
    /// 1857. Largest Color Value in a Directed Graph - Hard
    /// <a href="https://leetcode.com/problems/largest-color-value-in-a-directed-graph">See the problem</a>
    /// </summary>
    public int LargestPathValue(string colors, int[][] edges)
    {
        int n = colors.Length;
        var adj = new List<int>[n];
        for (int i = 0; i < n; i++) adj[i] = new List<int>();

        var indeg = new int[n];
        foreach (var e in edges)
        {
            adj[e[0]].Add(e[1]);
            indeg[e[1]]++;
        }

        // dp[u, c] = max count of color c in any path ending at u
        var dp = new int[n, 26];
        for (int i = 0; i < n; i++)
            dp[i, colors[i] - 'a'] = 1;

        var q = new Queue<int>();
        for (int i = 0; i < n; i++) if (indeg[i] == 0) q.Enqueue(i);

        int processed = 0;
        int answer = 0;

        while (q.Count > 0)
        {
            int u = q.Dequeue();
            processed++;

            // update global answer from node u
            for (int c = 0; c < 26; c++)
                if (dp[u, c] > answer) answer = dp[u, c];

            foreach (int v in adj[u])
            {
                // propagate counts to v; add 1 if we extend with v's color
                int vc = colors[v] - 'a';
                for (int c = 0; c < 26; c++)
                {
                    int candidate = dp[u, c] + (c == vc ? 1 : 0);
                    if (candidate > dp[v, c]) dp[v, c] = candidate;
                }

                if (--indeg[v] == 0) q.Enqueue(v);
            }
        }

        // If not all nodes processed, there is a cycle
        return processed == n ? answer : -1;
    }
}
