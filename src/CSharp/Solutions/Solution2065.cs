namespace LeetCode.Solutions;

public class Solution2065
{
    /// <summary>
    /// 2065. Maximum Path Quality of a Graph - Hard
    /// <a href="https://leetcode.com/problems/maximum-path-quality-of-a-graph">See the problem</a>
    /// </summary>
    public int MaximalPathQuality(int[] values, int[][] edges, int maxTime)
    {
        var n = values.Length;
        var graph = new List<(int to, int time)>[n];
        for (var i = 0; i < n; i++)
            graph[i] = [];

        foreach (var e in edges)
        {
            graph[e[0]].Add((e[1], e[2]));
            graph[e[1]].Add((e[0], e[2]));
        }

        var result = 0;
        var visited = new int[n];
        visited[0] = 1;

        Dfs(0, 0, values[0], graph, values, maxTime, visited, ref result);
        return result;
    }

    private static void Dfs(int node, int timeSpent, int quality,
        List<(int to, int time)>[] graph, int[] values, int maxTime,
        int[] visited, ref int result)
    {
        if (node == 0)
            result = Math.Max(result, quality);

        foreach (var (next, t) in graph[node])
        {
            if (timeSpent + t > maxTime) continue;
            var gain = visited[next] == 0 ? values[next] : 0;
            visited[next]++;
            Dfs(next, timeSpent + t, quality + gain, graph, values, maxTime, visited, ref result);
            visited[next]--;
        }
    }
}
