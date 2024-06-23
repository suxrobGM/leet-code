using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution207
{
    /// <summary>
    /// 207. Course Schedule - Medium
    /// <a href="https://leetcode.com/problems/course-schedule">See the problem</a>
    /// </summary>
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var graph = new Dictionary<int, List<int>>();
        var inDegree = new int[numCourses];

        foreach (var prerequisite in prerequisites)
        {
            var course = prerequisite[0];
            var prerequisiteCourse = prerequisite[1];

            if (!graph.ContainsKey(prerequisiteCourse))
            {
                graph[prerequisiteCourse] = new List<int>();
            }

            graph[prerequisiteCourse].Add(course);
            inDegree[course]++;
        }

        var queue = new Queue<int>();

        for (var i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        var count = 0;

        while (queue.Count > 0)
        {
            var course = queue.Dequeue();
            count++;

            if (graph.ContainsKey(course))
            {
                foreach (var nextCourse in graph[course])
                {
                    inDegree[nextCourse]--;

                    if (inDegree[nextCourse] == 0)
                    {
                        queue.Enqueue(nextCourse);
                    }
                }
            }
        }

        return count == numCourses;
    }
}
