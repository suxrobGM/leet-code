using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1129
{
    /// <summary>
    /// 1129. Shortest Path with Alternating Colors - Medium
    /// <a href="https://leetcode.com/problems/shortest-path-with-alternating-colors">See the problem</a>
    /// </summary>
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        var redGraph = new Dictionary<int, List<int>>();
        var blueGraph = new Dictionary<int, List<int>>();
        var result = new int[n];
        var visited = new HashSet<(int, int)>();
        var queue = new Queue<(int, int, int)>();

        foreach (var edge in redEdges)
        {
            if (!redGraph.ContainsKey(edge[0]))
            {
                redGraph[edge[0]] = new List<int>();
            }

            redGraph[edge[0]].Add(edge[1]);
        }

        foreach (var edge in blueEdges)
        {
            if (!blueGraph.ContainsKey(edge[0]))
            {
                blueGraph[edge[0]] = new List<int>();
            }

            blueGraph[edge[0]].Add(edge[1]);
        }

        queue.Enqueue((0, 0, 0));
        queue.Enqueue((0, 1, 0));

        while (queue.Count > 0)
        {
            var (node, color, step) = queue.Dequeue();

            if (!visited.Contains((node, color)))
            {
                visited.Add((node, color));
                result[node] = result[node] == 0 ? step : Math.Min(result[node], step);

                if (color == 0 && redGraph.ContainsKey(node))
                {
                    foreach (var next in redGraph[node])
                    {
                        queue.Enqueue((next, 1, step + 1));
                    }
                }
                else if (color == 1 && blueGraph.ContainsKey(node))
                {
                    foreach (var next in blueGraph[node])
                    {
                        queue.Enqueue((next, 0, step + 1));
                    }
                }
            }
        }

        for (var i = 1; i < n; i++)
        {
            if (!visited.Contains((i, 0)) && !visited.Contains((i, 1)))
            {
                result[i] = -1;
            }
        }

        return result;
    }
}
