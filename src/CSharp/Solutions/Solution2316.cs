namespace LeetCode.Solutions;

public class Solution2316
{
    /// <summary>
    /// 2316. Count Unreachable Pairs of Nodes in an Undirected Graph - Medium
    /// <a href="https://leetcode.com/problems/count-unreachable-pairs-of-nodes-in-an-undirected-graph">See the problem</a>
    /// </summary>
    public long CountPairs(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var visited = new bool[n];
        var stack = new Stack<int>();
        long pairs = 0;
        long remaining = n;

        for (var i = 0; i < n; i++)
        {
            if (visited[i])
            {
                continue;
            }

            long componentSize = 0;
            visited[i] = true;
            stack.Push(i);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                componentSize++;

                foreach (var neighbor in graph[node])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        stack.Push(neighbor);
                    }
                }
            }

            // Count pairs with nodes in components that have not been processed.
            remaining -= componentSize;
            pairs += componentSize * remaining;
        }

        return pairs;
    }
}
