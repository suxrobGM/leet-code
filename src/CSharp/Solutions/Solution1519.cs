using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1519
{
    /// <summary>
    /// 1519. Number of Nodes in the Sub-Tree With the Same Label - Medium
    /// <a href="https://leetcode.com/problems/number-of-nodes-in-the-sub-tree-with-the-same-label">See the problem</a>
    /// </summary>
    public int[] CountSubTrees(int n, int[][] edges, string labels)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = [];

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var result = new int[n];
        var labelCount = new int[n, 26]; // 26 letters in the alphabet

        void Dfs(int node, int parent)
        {
            int labelIndex = labels[node] - 'a';
            labelCount[node, labelIndex]++;

            foreach (var neighbor in graph[node])
            {
                if (neighbor == parent) continue;

                Dfs(neighbor, node);

                for (int i = 0; i < 26; i++)
                    labelCount[node, i] += labelCount[neighbor, i];
            }

            result[node] = labelCount[node, labelIndex];
        }

        Dfs(0, -1);
        return result;
    }
}
