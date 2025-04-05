using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1202
{
    /// <summary>
    /// 1202. Smallest String With Swaps - Medium
    /// <a href="https://leetcode.com/problems/smallest-string-with-swaps">See the problem</a>
    /// </summary>
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
    {
        var graph = new Dictionary<int, List<int>>();
        for (var i = 0; i < s.Length; i++)
        {
            graph[i] = [];
        }

        foreach (var pair in pairs)
        {
            graph[pair[0]].Add(pair[1]);
            graph[pair[1]].Add(pair[0]);
        }

        var visited = new bool[s.Length];
        var result = new char[s.Length];

        for (var i = 0; i < s.Length; i++)
        {
            if (!visited[i])
            {
                var indices = new List<int>();
                var chars = new List<char>();
                DFS(i, graph, visited, indices, chars, s);
                indices.Sort();
                chars.Sort();

                for (var j = 0; j < indices.Count; j++)
                {
                    result[indices[j]] = chars[j];
                }
            }
        }

        return new string(result.ToArray());
    }

    private static void DFS(int node, Dictionary<int, List<int>> graph, bool[] visited, List<int> indices,
        List<char> chars, string s)
    {
        visited[node] = true;
        indices.Add(node);
        chars.Add(s[node]);

        foreach (var neighbor in graph[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, graph, visited, indices, chars, s);
            }
        }
    }
}
