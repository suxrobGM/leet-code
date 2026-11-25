namespace LeetCode.Solutions;

public class Solution2368
{
    /// <summary>
    /// 2368. Reachable Nodes With Restrictions - Medium
    /// <a href="https://leetcode.com/problems/reachable-nodes-with-restrictions">See the problem</a>
    /// </summary>
    public int ReachableNodes(int n, int[][] edges, int[] restricted)
    {
        var neighbors = new List<int>[n];
        for (int node = 0; node < n; node++)
        {
            neighbors[node] = new List<int>();
        }

        foreach (int[] edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var visited = new bool[n];
        foreach (int node in restricted)
        {
            visited[node] = true;
        }

        var pending = new Stack<int>();
        pending.Push(0);
        visited[0] = true;
        int count = 0;

        while (pending.TryPop(out int node))
        {
            count++;
            foreach (int neighbor in neighbors[node])
            {
                if (visited[neighbor])
                {
                    continue;
                }

                visited[neighbor] = true;
                pending.Push(neighbor);
            }
        }

        return count;
    }
}
