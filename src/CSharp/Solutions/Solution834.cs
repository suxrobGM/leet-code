using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution834
{
    /// <summary>
    /// 834. Sum of Distances in Tree - Hard
    /// <a href="https://leetcode.com/problems/sum-of-distances-in-tree">See the problem</a>
    /// </summary>
    public int[] SumOfDistancesInTree(int n, int[][] edges)
    {
        // Build adjacency list
        var graph = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var count = new int[n]; // Number of nodes in the subtree of each node
        var answer = new int[n]; // Sum of distances for each node

        // First DFS: Compute count and answer[0]
        void FirstDFS(int node, int parent)
        {
            count[node] = 1; // Count itself
            foreach (var neighbor in graph[node])
            {
                if (neighbor == parent) continue; // Skip parent
                FirstDFS(neighbor, node);
                count[node] += count[neighbor];
                answer[0] += answer[neighbor] + count[neighbor];
            }
        }

        // Second DFS: Propagate the result
        void SecondDFS(int node, int parent)
        {
            foreach (var neighbor in graph[node])
            {
                if (neighbor == parent) continue; // Skip parent
                answer[neighbor] = answer[node] + (n - 2 * count[neighbor]);
                SecondDFS(neighbor, node);
            }
        }

        FirstDFS(0, -1);
        SecondDFS(0, -1);

        return answer;
    }
}
