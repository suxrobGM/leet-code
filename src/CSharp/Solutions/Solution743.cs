using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution743
{
    /// <summary>
    /// 743. Network Delay Time - Medium
    /// <a href="https://leetcode.com/problems/network-delay-time">See the problem</a>
    /// </summary>
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var graph = new Dictionary<int, List<(int, int)>>();
        foreach (var time in times)
        {
            if (!graph.ContainsKey(time[0]))
            {
                graph[time[0]] = [];
            }

            graph[time[0]].Add((time[1], time[2]));
        }

        var dist = new int[n + 1];
        Array.Fill(dist, int.MaxValue);
        dist[k] = 0;

        var visited = new bool[n + 1];

        while (true)
        {
            var x = -1;
            for (var i = 1; i <= n; i++)
            {
                if (!visited[i] && (x == -1 || dist[i] < dist[x]))
                {
                    x = i;
                }
            }

            if (x == -1)
            {
                break;
            }

            visited[x] = true;
            if (graph.ContainsKey(x))
            {
                foreach (var edge in graph[x])
                {
                    dist[edge.Item1] = Math.Min(dist[edge.Item1], dist[x] + edge.Item2);
                }
            }
        }

        var ans = dist.Skip(1).Max();
        return ans == int.MaxValue ? -1 : ans;
    }
}
