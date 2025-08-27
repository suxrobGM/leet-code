using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1761
{
    /// <summary>
    /// 1761. Minimum Degree of a Connected Trio in a Graph - Hard
    /// <a href="https://leetcode.com/problems/minimum-degree-of-a-connected-trio-in-a-graph">See the problem</a>
    /// </summary>
    public int MinTrioDegree(int n, int[][] edges)
    {
        bool[,] adj = new bool[n + 1, n + 1]; // adjacency matrix
        int[] degree = new int[n + 1];

        // Build graph
        foreach (var e in edges)
        {
            int u = e[0], v = e[1];
            adj[u, v] = true;
            adj[v, u] = true;
            degree[u]++;
            degree[v]++;
        }

        int minDeg = int.MaxValue;

        // Check all trios (i < j < k)
        for (int i = 1; i <= n; i++)
        {
            for (int j = i + 1; j <= n; j++)
            {
                if (!adj[i, j]) continue;
                for (int k = j + 1; k <= n; k++)
                {
                    if (adj[i, k] && adj[j, k])
                    {
                        // Trio found
                        int d = degree[i] + degree[j] + degree[k] - 6;
                        minDeg = Math.Min(minDeg, d);
                    }
                }
            }
        }

        return minDeg == int.MaxValue ? -1 : minDeg;
    }
}
