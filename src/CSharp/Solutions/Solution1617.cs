using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1617
{
    /// <summary>
    /// 1617. Count Subtrees With Max Distance Between Cities - Hard
    /// <a href="https://leetcode.com/problems/count-subtrees-with-max-distance-between-cities">See the problem</a>
    /// </summary>
    public int[] CountSubgraphsForEachDiameter(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; ++i) graph[i] = new List<int>();
        foreach (var edge in edges)
        {
            int u = edge[0] - 1, v = edge[1] - 1;
            graph[u].Add(v);
            graph[v].Add(u);
        }

        int[] result = new int[n - 1];

        // Go through all subsets (bitmask from 1 to 2^n - 1)
        for (int mask = 1; mask < (1 << n); ++mask)
        {
            // Skip if only 1 node
            if ((mask & (mask - 1)) == 0) continue;

            // Try to extract nodes in the mask
            var nodes = new List<int>();
            for (int i = 0; i < n; ++i)
                if (((mask >> i) & 1) == 1)
                    nodes.Add(i);

            // Check if connected using BFS
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(nodes[0]);
            visited.Add(nodes[0]);

            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                foreach (var nei in graph[curr])
                {
                    if (!visited.Contains(nei) && ((mask >> nei) & 1) == 1)
                    {
                        visited.Add(nei);
                        queue.Enqueue(nei);
                    }
                }
            }

            if (visited.Count != nodes.Count) continue; // not a connected subset

            // Now compute diameter (maximum shortest path between any two nodes)
            int diameter = 0;
            foreach (var u in nodes)
            {
                var dist = new int[n];
                Array.Fill(dist, -1);
                var q = new Queue<int>();
                q.Enqueue(u);
                dist[u] = 0;
                int localMax = 0;

                while (q.Count > 0)
                {
                    int curr = q.Dequeue();
                    foreach (var nei in graph[curr])
                    {
                        if (dist[nei] == -1 && ((mask >> nei) & 1) == 1)
                        {
                            dist[nei] = dist[curr] + 1;
                            localMax = Math.Max(localMax, dist[nei]);
                            q.Enqueue(nei);
                        }
                    }
                }

                diameter = Math.Max(diameter, localMax);
            }

            if (diameter > 0) result[diameter - 1]++;
        }

        return result;
    }
}
