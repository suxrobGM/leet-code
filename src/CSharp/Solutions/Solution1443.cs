namespace LeetCode.Solutions;

public class Solution1443
{
    /// <summary>
    /// 1443. Minimum Time to Collect All Apples in a Tree - Medium
    /// <a href="https://leetcode.com/problems/minimum-time-to-collect-all-apples-in-a-tree">See the problem</a>
    /// </summary>
    public int MinTime(int n, int[][] edges, IList<bool> hasApple)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        return DFS(0, -1, graph, hasApple);
    }

    private int DFS(int node, int parent, List<int>[] graph, IList<bool> hasApple)
    {
        int totalTime = 0;

        foreach (var neighbor in graph[node])
        {
            if (neighbor == parent) continue; // Avoid going back to the parent node

            int time = DFS(neighbor, node, graph, hasApple);
            if (time > 0 || hasApple[neighbor])
            {
                totalTime += time + 2; // Add time for the edge and return
            }
        }

        return totalTime;
    }
}
