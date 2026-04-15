using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2101
{
    /// <summary>
    /// 2101. Detonate the Maximum Bombs - Medium
    /// <a href="https://leetcode.com/problems/detonate-the-maximum-bombs">See the problem</a>
    /// </summary>
    public int MaximumDetonation(int[][] bombs)
    {
        var n = bombs.Length;
        var graph = new List<int>[n];
        for (var i = 0; i < n; i++) graph[i] = new List<int>();

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i != j)
                {
                    long dx = bombs[i][0] - bombs[j][0];
                    long dy = bombs[i][1] - bombs[j][1];
                    long r = bombs[i][2];
                    if (dx * dx + dy * dy <= r * r)
                        graph[i].Add(j);
                }
            }
        }

        var best = 0;
        for (var i = 0; i < n; i++)
        {
            best = Math.Max(best, Bfs(graph, i, n));
        }

        return best;
    }

    private int Bfs(List<int>[] graph, int start, int n)
    {
        var visited = new bool[n];
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;
        var count = 0;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            count++;
            foreach (var next in graph[node])
                if (!visited[next])
                {
                    visited[next] = true;
                    queue.Enqueue(next);
                }
        }

        return count;
    }
}
