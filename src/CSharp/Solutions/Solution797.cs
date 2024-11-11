
namespace LeetCode.Solutions;

public class Solution797
{
    /// <summary>
    /// 797. All Paths From Source to Target - Medium
    /// <a href="https://leetcode.com/problems/all-paths-from-source-to-target">See the problem</a>
    /// </summary>
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var result = new List<IList<int>>();
        var path = new List<int> { 0 };

        Dfs(graph, 0, path, result);

        return result;
    }

    private void Dfs(int[][] graph, int node, List<int> path, List<IList<int>> result)
    {
        if (node == graph.Length - 1)
        {
            result.Add(new List<int>(path));
            return;
        }

        foreach (var nextNode in graph[node])
        {
            path.Add(nextNode);
            Dfs(graph, nextNode, path, result);
            path.RemoveAt(path.Count - 1);
        }
    }
}
