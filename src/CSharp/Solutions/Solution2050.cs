namespace LeetCode.Solutions;

public class Solution2050
{
    /// <summary>
    /// 2050. Parallel Courses III - Hard
    /// <a href="https://leetcode.com/problems/parallel-courses-iii">See the problem</a>
    /// </summary>
    public int MinimumTime(int n, int[][] relations, int[] time)
    {
        var graph = new List<int>[n + 1];
        var inDegree = new int[n + 1];
        for (var i = 1; i <= n; i++)
            graph[i] = [];

        foreach (var r in relations)
        {
            graph[r[0]].Add(r[1]);
            inDegree[r[1]]++;
        }

        var dist = new int[n + 1];
        var queue = new Queue<int>();
        for (var i = 1; i <= n; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
                dist[i] = time[i - 1];
            }
        }

        while (queue.Count > 0)
        {
            var course = queue.Dequeue();
            foreach (var next in graph[course])
            {
                dist[next] = Math.Max(dist[next], dist[course] + time[next - 1]);
                if (--inDegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        return dist.Max();
    }
}
