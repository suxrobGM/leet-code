
namespace LeetCode.Solutions;

public class Solution802
{
    /// <summary>
    /// 802. Find Eventual Safe States - Medium
    /// <a href="https://leetcode.com/problems/find-eventual-safe-states">See the problem</a>
    /// </summary>
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        var n = graph.Length;
        var color = new int[n];

        var result = new List<int>();

        for (var i = 0; i < n; i++)
        {
            if (Dfs(graph, color, i))
            {
                result.Add(i);
            }
        }

        return result;
    }

    private bool Dfs(int[][] graph, int[] color, int node)
    {
        if (color[node] > 0)
        {
            return color[node] == 2;
        }

        color[node] = 1;

        foreach (var next in graph[node])
        {
            if (color[next] == 2)
            {
                continue;
            }

            if (color[next] == 1 || !Dfs(graph, color, next))
            {
                return false;
            }
        }

        color[node] = 2;

        return true;
    }
}
