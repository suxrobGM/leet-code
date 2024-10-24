namespace LeetCode.Solutions;

public class Solution684
{
    /// <summary>
    /// 684. Redundant Connection - Medium
    /// <a href="https://leetcode.com/problems/redundant-connection">See the problem</a>
    /// </summary>
    public int[] FindRedundantConnection(int[][] edges)
    {
        var parent = new int[edges.Length + 1];
        for (var i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
        }

        foreach (var edge in edges)
        {
            var root1 = Find(parent, edge[0]);
            var root2 = Find(parent, edge[1]);

            if (root1 == root2)
            {
                return edge;
            }

            parent[root1] = root2;
        }

        return [];
    }

    private static int Find(int[] parent, int x)
    {
        while (parent[x] != x)
        {
            x = parent[x];
        }

        return x;
    }
}
