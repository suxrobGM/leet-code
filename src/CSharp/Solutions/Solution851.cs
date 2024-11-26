using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution851
{
    /// <summary>
    /// 851. Loud and Rich - Medium
    /// <a href="https://leetcode.com/problems/loud-and-rich">See the problem</a>
    /// </summary>
    public int[] LoudAndRich(int[][] richer, int[] quiet)
    {
        var n = quiet.Length;
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }

        // Build the graph: richer[i] = [a, b] means a -> b
        foreach (var pair in richer)
        {
            graph[pair[1]].Add(pair[0]);
        }

        var answer = new int[n];
        Array.Fill(answer, -1);

        // DFS function to find the least quiet person
        int DFS(int node)
        {
            if (answer[node] != -1)
            {
                return answer[node]; // Already computed
            }

            // Initialize the quietest person as the current node
            answer[node] = node;

            foreach (var neighbor in graph[node])
            {
                int candidate = DFS(neighbor);
                if (quiet[candidate] < quiet[answer[node]])
                {
                    answer[node] = candidate;
                }
            }

            return answer[node];
        }

        // Compute the answer for each person
        for (int i = 0; i < n; i++)
        {
            DFS(i);
        }

        return answer;
    }
}
