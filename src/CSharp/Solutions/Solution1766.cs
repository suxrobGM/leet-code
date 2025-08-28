using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1766
{
    /// <summary>
    /// 1766. Tree of Coprimes - Hard
    /// <a href="https://leetcode.com/problems/tree-of-coprimes">See the problem</a>
    /// </summary>
    public int[] GetCoprimes(int[] nums, int[][] edges)
    {
        int n = nums.Length;
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = new List<int>();
        foreach (var e in edges)
        {
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }

        // Precompute coprime relationships
        var coprime = new bool[51, 51];
        for (int i = 1; i <= 50; i++)
        {
            for (int j = 1; j <= 50; j++)
            {
                coprime[i, j] = Gcd(i, j) == 1;
            }
        }

        int[] ans = new int[n];
        Array.Fill(ans, -1);

        // Track the latest ancestor index for each value
        (int node, int depth)[] latest = new (int, int)[51];
        for (int i = 0; i <= 50; i++) latest[i] = (-1, -1);

        Dfs(0, -1, 0);

        return ans;

        void Dfs(int u, int parent, int depth)
        {
            int val = nums[u];
            int bestNode = -1, bestDepth = -1;

            // Find closest coprime ancestor
            for (int v = 1; v <= 50; v++)
            {
                if (coprime[val, v] && latest[v].node != -1)
                {
                    if (latest[v].depth > bestDepth)
                    {
                        bestDepth = latest[v].depth;
                        bestNode = latest[v].node;
                    }
                }
            }
            ans[u] = bestNode;

            // Save state
            var prev = latest[val];
            latest[val] = (u, depth);

            foreach (var nei in graph[u])
            {
                if (nei == parent) continue;
                Dfs(nei, u, depth + 1);
            }

            // Restore state (backtrack)
            latest[val] = prev;
        }

        int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int t = a % b;
                a = b;
                b = t;
            }
            return a;
        }
    }
}
