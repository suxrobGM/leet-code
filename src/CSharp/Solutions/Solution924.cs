using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution924
{
    /// <summary>
    /// 924. Minimize Malware Spread - Hard
    /// <a href="https://leetcode.com/problems/minimize-malware-spread">See the problem</a>
    /// </summary>
    public int MinMalwareSpread(int[][] graph, int[] initial)
    {
        int n = graph.Length;

        // Step 1: Find connected components using DFS
        int[] component = new int[n];
        Array.Fill(component, -1);
        int componentId = 0;

        for (int i = 0; i < n; i++)
        {
            if (component[i] == -1)
            {
                DFS(graph, i, component, componentId);
                componentId++;
            }
        }

        // Step 2: Calculate the size of each component
        int[] componentSize = new int[componentId];
        for (int i = 0; i < n; i++)
        {
            componentSize[component[i]]++;
        }

        // Step 3: Count the number of initially infected nodes in each component
        int[] infectedCount = new int[componentId];
        foreach (int node in initial)
        {
            infectedCount[component[node]]++;
        }

        // Step 4: Evaluate the impact of removing each node in initial
        int result = -1;
        int maxSaved = -1;
        Array.Sort(initial); // Break ties by smallest index
        foreach (int node in initial)
        {
            int compId = component[node];
            if (infectedCount[compId] == 1)
            { // This node is the only infected in its component
                if (componentSize[compId] > maxSaved)
                {
                    maxSaved = componentSize[compId];
                    result = node;
                }
            }
        }

        // Step 5: If no node can save any component, return the smallest index
        return result == -1 ? initial[0] : result;
    }

    private void DFS(int[][] graph, int node, int[] component, int compId)
    {
        component[node] = compId;
        for (int neighbor = 0; neighbor < graph.Length; neighbor++)
        {
            if (graph[node][neighbor] == 1 && component[neighbor] == -1)
            {
                DFS(graph, neighbor, component, compId);
            }
        }
    }
}
