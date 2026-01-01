namespace LeetCode.Solutions;

public class Solution1971
{
    /// <summary>
    /// 1971. Find if Path Exists in Graph - Easy
    /// <a href="https://leetcode.com/problems/find-the-town-judge">See the problem</a>
    /// </summary>
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var graph = new Dictionary<int, List<int>>();

        // Build graph from edges list (undirected graph)
        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = [];
            }

            if (!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = [];
            }

            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        // BFS
        var visited = new bool[n];
        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current == destination)
            {
                return true;
            }

            visited[current] = true;

            if (graph.ContainsKey(current))
            {
                foreach (var neighbor in graph[current])
                {
                    if (!visited[neighbor])
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        return false;
    }
}
