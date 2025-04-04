using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1192
{
    private int time = 0;

    /// <summary>
    /// 1192. Critical Connections in a Network - Hard
    /// <a href="https://leetcode.com/problems/critical-connections-in-a-network">See the problem</a>
    /// </summary>
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var connection in connections)
        {
            graph[connection[0]].Add(connection[1]);
            graph[connection[1]].Add(connection[0]);
        }

        var result = new List<IList<int>>();
        var visited = new bool[n];
        var low = new int[n];
        var disc = new int[n];
        var parent = new int[n];

        for (int i = 0; i < n; i++)
        {
            parent[i] = -1;
            disc[i] = -1;
            low[i] = -1;
        }

        for (int i = 0; i < n; i++)
        {
            if (disc[i] == -1)
            {
                DFS(i, visited, disc, low, parent, result, graph);
            }
        }

        return result;
    }

    private void DFS(int u, bool[] visited, int[] disc, int[] low, int[] parent, List<IList<int>> result,
        List<int>[] graph)
    {
        visited[u] = true;
        disc[u] = low[u] = ++time;

        foreach (var v in graph[u])
        {
            if (!visited[v])
            {
                parent[v] = u;
                DFS(v, visited, disc, low, parent, result, graph);

                low[u] = Math.Min(low[u], low[v]);

                if (low[v] > disc[u])
                {
                    result.Add(new List<int> { u, v });
                }
            }
            else if (v != parent[u])
            {
                low[u] = Math.Min(low[u], disc[v]);
            }
        }
    }
}
