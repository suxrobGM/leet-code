using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution928
{
    /// <summary>
    /// 928. Minimize Malware Spread II - Hard
    /// <a href="https://leetcode.com/problems/minimize-malware-spread-ii">See the problem</a>
    /// </summary>
    public int MinMalwareSpread(int[][] graph, int[] initial)
    {
        int n = graph.Length;

        // Step 1: Find connected components
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

        // Step 3: Count infected nodes in each component
        int[] infectedCount = new int[componentId];
        foreach (int node in initial)
        {
            infectedCount[component[node]]++;
        }

        // Step 4: Evaluate node removal
        int result = -1;
        int maxSaved = -1;
        Array.Sort(initial); // Sort to handle ties by smallest index

        foreach (int node in initial)
        {
            int compId = component[node];
            if (infectedCount[compId] == 1)
            { // Only one infected node in this component
                int saved = componentSize[compId];
                if (saved > maxSaved || (saved == maxSaved && node < result))
                {
                    maxSaved = saved;
                    result = node;
                }
            }
        }

        // Step 5: Return result
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
