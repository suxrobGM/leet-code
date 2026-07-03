namespace LeetCode.Solutions;

public class Solution2192
{
    /// <summary>
    /// 2192. All Ancestors of a Node in a Directed Acyclic Graph - Medium
    /// <a href="https://leetcode.com/problems/all-ancestors-of-a-node-in-a-directed-acyclic-graph">See the problem</a>
    /// </summary>
    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
        }

        var result = new List<IList<int>>();
        for (int i = 0; i < n; i++)
        {
            result.Add(new List<int>());
        }

        for (int ancestor = 0; ancestor < n; ancestor++)
        {
            var visited = new bool[n];
            var queue = new Queue<int>();
            queue.Enqueue(ancestor);
            visited[ancestor] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbor in graph[node])
                {
                    if (visited[neighbor])
                    {
                        continue;
                    }

                    visited[neighbor] = true;
                    result[neighbor].Add(ancestor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }
}
