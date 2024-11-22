using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution847
{
    /// <summary>
    /// 847. Shortest Path Visiting All Nodes - Hard
    /// <a href="https://leetcode.com/problems/shortest-path-visiting-all-nodes">See the problem</a>
    /// </summary>
    public int ShortestPathLength(int[][] graph)
    {
        int n = graph.Length;
        int target = (1 << n) - 1;
        var queue = new Queue<(int node, int state, int distance)>();
        var visited = new bool[n, 1 << n];

        for (int i = 0; i < n; i++)
        {
            queue.Enqueue((i, 1 << i, 0));
            visited[i, 1 << i] = true;
        }

        while (queue.Count > 0)
        {
            var (node, state, distance) = queue.Dequeue();

            if (state == target)
            {
                return distance;
            }

            foreach (int next in graph[node])
            {
                int nextState = state | (1 << next);

                if (!visited[next, nextState])
                {
                    queue.Enqueue((next, nextState, distance + 1));
                    visited[next, nextState] = true;
                }
            }
        }

        return -1;
    }
}
