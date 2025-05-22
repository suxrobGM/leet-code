using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1462
{
    /// <summary>
    /// 1462. Course Schedule IV - Medium
    /// <a href="https://leetcode.com/problems/course-schedule-iv">See the problem</a>
    /// </summary>
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        var graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
            graph[i] = [];

        foreach (var prerequisite in prerequisites)
        {
            graph[prerequisite[0]].Add(prerequisite[1]);
        }

        var result = new List<bool>();
        foreach (var query in queries)
        {
            var visited = new bool[numCourses];
            result.Add(DFS(graph, query[0], query[1], visited));
        }

        return result;
    }

    private bool DFS(List<int>[] graph, int start, int target, bool[] visited)
    {
        if (start == target)
            return true;

        visited[start] = true;

        foreach (var neighbor in graph[start])
        {
            if (!visited[neighbor] && DFS(graph, neighbor, target, visited))
                return true;
        }

        return false;
    }
}
