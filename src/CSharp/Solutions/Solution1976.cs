namespace LeetCode.Solutions;

public class Solution1976
{
    /// <summary>
    /// 1976. Number of Ways to Arrive at Destination - Medium
    /// <a href="https://leetcode.com/problems/number-of-ways-to-arrive-at-destination">See the problem</a>
    /// </summary>
    public int CountPaths(int n, int[][] roads)
    {
        const int MOD = 1_000_000_007;
        var graph = new List<(int to, int time)>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }

        foreach (var road in roads)
        {
            int u = road[0], v = road[1], time = road[2];
            graph[u].Add((v, time));
            graph[v].Add((u, time));
        }

        var minTime = new long[n];
        var ways = new int[n];
        for (int i = 0; i < n; i++)
        {
            minTime[i] = long.MaxValue;
            ways[i] = 0;
        }
        minTime[0] = 0;
        ways[0] = 1;

        var pq = new PriorityQueue<(int node, long time), long>();
        pq.Enqueue((0, 0), 0);

        while (pq.Count > 0)
        {
            var (node, time) = pq.Dequeue();

            if (time > minTime[node])
                continue;

            foreach (var (to, travelTime) in graph[node])
            {
                long newTime = time + travelTime;
                if (newTime < minTime[to])
                {
                    minTime[to] = newTime;
                    ways[to] = ways[node];
                    pq.Enqueue((to, newTime), newTime);
                }
                else if (newTime == minTime[to])
                {
                    ways[to] = (ways[to] + ways[node]) % MOD;
                }
            }
        }

        return ways[n - 1];
    }
}
