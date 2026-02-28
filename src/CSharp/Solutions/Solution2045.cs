namespace LeetCode.Solutions;

public class Solution2045
{
    /// <summary>
    /// 2045. Second Minimum Time to Reach Destination - Hard
    /// <a href="https://leetcode.com/problems/second-minimum-time-to-reach-destination">See the problem</a>
    /// </summary>
    public int SecondMinimum(int n, int[][] edges, int time, int change)
    {
        var graph = new List<int>[n + 1];
        for (var i = 0; i <= n; i++)
            graph[i] = [];

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var queue = new Queue<(int node, int time)>();
        queue.Enqueue((1, 0));
        var times = new List<int>[n + 1];
        for (var i = 0; i <= n; i++)
            times[i] = [];

        while (queue.Count > 0)
        {
            var (node, timeSoFar) = queue.Dequeue();
            if (times[node].Count == 2)
                continue;
            if (times[node].Count == 1 && times[node][0] == timeSoFar)
                continue;

            times[node].Add(timeSoFar);
            foreach (var next in graph[node])
            {
                var nextTime = timeSoFar;
                if (nextTime % (2 * change) >= change)
                    nextTime += 2 * change - nextTime % (2 * change);

                nextTime += time;
                queue.Enqueue((next, nextTime));
            }
        }

        return times[n][1];
    }
}
