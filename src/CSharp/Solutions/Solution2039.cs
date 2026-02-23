namespace LeetCode.Solutions;

public class Solution2039
{
    /// <summary>
    /// 2039. The Time When the Network Becomes Idle - Medium
    /// <a href="https://leetcode.com/problems/the-time-when-the-network-becomes-idle">See the problem</a>
    /// </summary>
    public int NetworkBecomesIdle(int[][] edges, int[] patience)
    {
        var graph = new Dictionary<int, List<int>>();

        for (var i = 0; i < edges.Length; i++)
        {
            if (!graph.ContainsKey(edges[i][0]))
                graph[edges[i][0]] = new List<int>();

            if (!graph.ContainsKey(edges[i][1]))
                graph[edges[i][1]] = new List<int>();

            graph[edges[i][0]].Add(edges[i][1]);
            graph[edges[i][1]].Add(edges[i][0]);
        }

        var queue = new Queue<(int node, int time)>();
        var visited = new HashSet<int>();

        queue.Enqueue((0, 0));
        visited.Add(0);

        var maxTime = 0;

        while (queue.Count > 0)
        {
            var (node, time) = queue.Dequeue();

            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue((neighbor, time + 1));

                    var roundTrips = (time + 1) * 2;
                    var lastMessageTime = roundTrips + ((roundTrips - 1) / patience[neighbor]) * patience[neighbor];
                    maxTime = Math.Max(maxTime, lastMessageTime);
                }
            }
        }

        return maxTime + 1;
    }
}
