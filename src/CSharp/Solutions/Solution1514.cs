using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1514
{
    /// <summary>
    /// 1514. Path with Maximum Probability - Medium
    /// <a href="https://leetcode.com/problems/path-with-maximum-probability">See the problem</a>
    /// </summary>
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
    {
        var graph = new Dictionary<int, List<(int node, double prob)>>();

        for (int i = 0; i < edges.Length; i++)
        {
            int a = edges[i][0], b = edges[i][1];
            double p = succProb[i];

            if (!graph.ContainsKey(a)) graph[a] = new();
            if (!graph.ContainsKey(b)) graph[b] = new();

            graph[a].Add((b, p));
            graph[b].Add((a, p));
        }

        var maxProb = new double[n];
        maxProb[start_node] = 1.0;

        var pq = new PriorityQueue<int, double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));
        pq.Enqueue(start_node, 1.0);

        while (pq.Count > 0)
        {
            int node = pq.Dequeue();

            if (node == end_node)
                return maxProb[end_node];

            if (!graph.ContainsKey(node)) continue;

            foreach (var (neighbor, prob) in graph[node])
            {
                double newProb = maxProb[node] * prob;
                if (newProb > maxProb[neighbor])
                {
                    maxProb[neighbor] = newProb;
                    pq.Enqueue(neighbor, newProb);
                }
            }
        }

        return 0.0;
    }
}
