using System.Text;

namespace LeetCode.Solutions;

public class Solution1791
{
    /// <summary>
    /// 1791. Find Center of Star Graph - Easy
    /// <a href="https://leetcode.com/problems/find-center-of-star-graph">See the problem</a>
    /// </summary>
    public int FindCenter(int[][] edges)
    {
        // The center of a star graph is the node that is connected to all other nodes.
        // In a star graph with n nodes, there are n-1 edges.
        // The center will be the node that appears in all edges.
        int[] degree = new int[edges.Length + 2];
        foreach (var edge in edges)
        {
            degree[edge[0]]++;
            degree[edge[1]]++;
        }
        for (int i = 1; i < degree.Length; i++)
        {
            if (degree[i] == edges.Length)
            {
                return i;
            }
        }
        return -1; // This line should never be reached for a valid star graph.
    }
}

