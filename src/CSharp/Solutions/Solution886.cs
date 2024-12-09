using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution886
{
    /// <summary>
    /// 886. Possible Bipartition - Medium
    /// <a href="https://leetcode.com/problems/possible-bipartition">See the problem</a>
    /// </summary>
    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        var graph = new Dictionary<int, List<int>>();

        foreach (var dislike in dislikes)
        {
            if (!graph.ContainsKey(dislike[0]))
            {
                graph[dislike[0]] = new List<int>();
            }

            if (!graph.ContainsKey(dislike[1]))
            {
                graph[dislike[1]] = new List<int>();
            }

            graph[dislike[0]].Add(dislike[1]);
            graph[dislike[1]].Add(dislike[0]);
        }

        var colors = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            if (colors[i] == 0 && !DFS(graph, colors, i, 1))
            {
                return false;
            }
        }

        return true;
    }

    private bool DFS(Dictionary<int, List<int>> graph, int[] colors, int node, int color)
    {
        if (colors[node] != 0)
        {
            return colors[node] == color;
        }

        colors[node] = color;

        if (!graph.ContainsKey(node))
        {
            return true;
        }

        foreach (var neighbor in graph[node])
        {
            if (!DFS(graph, colors, neighbor, -color))
            {
                return false;
            }
        }

        return true;
    }
}
