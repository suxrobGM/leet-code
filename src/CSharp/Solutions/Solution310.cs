namespace LeetCode.Solutions;

public class Solution310
{
    /// <summary>
    /// 310. Minimum Height Trees - Medium
    /// <a href="https://leetcode.com/problems/minimum-height-trees">See the problem</a>
    /// </summary>
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n == 1)
        {
            return [0];
        }

        var graph = new Dictionary<int, List<int>>();
        var degrees = new int[n];

        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = new List<int>();
            }

            if (!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = new List<int>();
            }

            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);

            degrees[edge[0]]++;
            degrees[edge[1]]++;
        }

        var leaves = new Queue<int>();
        for (var i = 0; i < n; i++)
        {
            if (degrees[i] == 1)
            {
                leaves.Enqueue(i);
            }
        }

        var remainingNodes = n;
        while (remainingNodes > 2)
        {
            var leavesCount = leaves.Count;
            remainingNodes -= leavesCount;

            for (var i = 0; i < leavesCount; i++)
            {
                var leaf = leaves.Dequeue();
                degrees[leaf]--;

                foreach (var neighbor in graph[leaf])
                {
                    degrees[neighbor]--;

                    if (degrees[neighbor] == 1)
                    {
                        leaves.Enqueue(neighbor);
                    }
                }
            }
        }

        return [.. leaves];
    }
}
