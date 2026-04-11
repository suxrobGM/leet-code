using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2097
{
    /// <summary>
    /// 2097. Valid Arrangement of Pairs - Hard
    /// <a href="https://leetcode.com/problems/valid-arrangement-of-pairs">See the problem</a>
    /// </summary>
    public int[][] ValidArrangement(int[][] pairs)
    {
        var graph = new Dictionary<int, Stack<int>>();
        var degree = new Dictionary<int, int>(); // out - in

        foreach (var pair in pairs)
        {
            int start = pair[0], end = pair[1];
            if (!graph.ContainsKey(start)) graph[start] = new Stack<int>();
            graph[start].Push(end);

            degree[start] = degree.GetValueOrDefault(start) + 1;
            degree[end] = degree.GetValueOrDefault(end) - 1;
        }

        // Find start node: node with out - in == 1, or any node if Eulerian circuit
        var startNode = pairs[0][0];
        foreach (var (node, deg) in degree)
            if (deg == 1) { startNode = node; break; }

        var path = new Stack<int>();
        var stack = new Stack<int>();
        stack.Push(startNode);

        while (stack.Count > 0)
        {
            var node = stack.Peek();
            if (graph.ContainsKey(node) && graph[node].Count > 0)
                stack.Push(graph[node].Pop());
            else
            {
                path.Push(node);
                stack.Pop();
            }
        }

        var nodes = path.ToArray();
        var result = new int[nodes.Length - 1][];
        for (var i = 0; i < result.Length; i++)
            result[i] = [nodes[i], nodes[i + 1]];

        return result;
    }
}
