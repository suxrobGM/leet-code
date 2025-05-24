using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1466
{
    /// <summary>
    /// 1466. Reorder Routes to Make All Paths Lead to the City Zero - Medium
    /// <a href="https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero">See the problem</a>
    /// </summary>
    public int MinReorder(int n, int[][] connections)
    {
        var graph = new Dictionary<int, List<(int, bool)>>();

        foreach (var connection in connections)
        {
            if (!graph.ContainsKey(connection[0]))
                graph[connection[0]] = new List<(int, bool)>();
            if (!graph.ContainsKey(connection[1]))
                graph[connection[1]] = new List<(int, bool)>();

            graph[connection[0]].Add((connection[1], true));
            graph[connection[1]].Add((connection[0], false));
        }

        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        queue.Enqueue(0);
        visited.Add(0);

        int reorderCount = 0;

        while (queue.Count > 0)
        {
            int city = queue.Dequeue();

            foreach (var (neighbor, isReversed) in graph[city])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                    if (isReversed)
                        reorderCount++;
                }
            }
        }

        return reorderCount;
    }
}
