namespace LeetCode.Solutions;

public class Solution210
{
    /// <summary>
    /// 210. Course Schedule II - Medium
    /// <a href="https://leetcode.com/problems/course-schedule-ii">See the problem</a>
    /// </summary>
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var graph = new Dictionary<int, List<int>>();
        var inDegrees = new int[numCourses];
        var queue = new Queue<int>();
        var result = new List<int>();

        // Build the graph
        foreach (var prerequisite in prerequisites)
        {
            if (!graph.ContainsKey(prerequisite[1]))
            {
                graph[prerequisite[1]] = new List<int>();
            }

            graph[prerequisite[1]].Add(prerequisite[0]);
            inDegrees[prerequisite[0]]++;
        }
        
        // Add courses with no prerequisites to the queue
        for (var i = 0; i < numCourses; i++)
        {
            if (inDegrees[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        // Topological sort
        while (queue.Count > 0)
        {
            var course = queue.Dequeue();
            result.Add(course);

            if (graph.ContainsKey(course))
            {
                foreach (var nextCourse in graph[course])
                {
                    inDegrees[nextCourse]--;

                    if (inDegrees[nextCourse] == 0)
                    {
                        queue.Enqueue(nextCourse);
                    }
                }
            }
        }

        return result.Count == numCourses ? [.. result] : [];
    }
}
