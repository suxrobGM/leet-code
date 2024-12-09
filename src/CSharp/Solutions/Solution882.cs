using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution882
{
    /// <summary>
    /// 882. Reachable Nodes In Subdivided Graph - Hard
    /// <a href="https://leetcode.com/problems/reachable-nodes-in-subdivided-graph">See the problem</a>
    /// </summary>
    public int ReachableNodes(int[][] edges, int maxMoves, int n)
    {
        // Build the adjacency list for the original graph
        var graph = new Dictionary<int, List<(int neighbor, int weight)>>();
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }

        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1], cnt = edge[2];
            graph[u].Add((v, cnt + 1));
            graph[v].Add((u, cnt + 1));
        }

        // Dijkstra's algorithm to find shortest paths
        var pq = new PriorityQueue<(int node, int movesLeft), int>();
        pq.Enqueue((0, maxMoves), -maxMoves);

        var distance = new Dictionary<int, int>
        {
            [0] = maxMoves
        };

        var used = new Dictionary<(int, int), int>();
        int reachableNodes = 0;

        while (pq.Count > 0)
        {
            var (node, movesLeft) = pq.Dequeue();

            // Skip if we've already visited with a better distance
            if (movesLeft < distance[node]) continue;

            // Count the current node as reachable
            reachableNodes++;

            // Process neighbors
            foreach (var (neighbor, weight) in graph[node])
            {
                int remainingMoves = movesLeft - weight;

                // Count the reachable intermediate nodes on this edge
                if (!used.ContainsKey((node, neighbor))) used[(node, neighbor)] = 0;
                used[(node, neighbor)] = Math.Min(weight - 1, movesLeft);

                if (remainingMoves >= 0 && (!distance.ContainsKey(neighbor) || remainingMoves > distance[neighbor]))
                {
                    distance[neighbor] = remainingMoves;
                    pq.Enqueue((neighbor, remainingMoves), -remainingMoves);
                }
            }
        }

        // Count reachable intermediate nodes
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1], cnt = edge[2];
            reachableNodes += Math.Min(cnt, used.GetValueOrDefault((u, v), 0) + used.GetValueOrDefault((v, u), 0));
        }

        return reachableNodes;
    }
}
