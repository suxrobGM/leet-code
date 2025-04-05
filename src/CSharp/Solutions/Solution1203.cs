using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1203
{
    /// <summary>
    /// 1203. Sort Items by Groups Respecting Dependencies - Hard
    /// <a href="https://leetcode.com/problems/sort-items-by-groups-respecting-dependencies">See the problem</a>
    /// </summary>
    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
    {
        // Step 1: Assign unique group to ungrouped items
        int newGroupId = m;
        for (int i = 0; i < n; i++)
        {
            if (group[i] == -1)
                group[i] = newGroupId++;
        }

        // Step 2: Build graphs
        var itemGraph = new Dictionary<int, List<int>>();
        var itemIndegree = new int[n];

        var groupGraph = new Dictionary<int, List<int>>();
        var groupIndegree = new int[newGroupId];

        for (int i = 0; i < n; i++)
        {
            itemGraph[i] = [];
        }
        for (int i = 0; i < newGroupId; i++)
        {
            groupGraph[i] = [];
        }

        for (int i = 0; i < n; i++)
        {
            foreach (int before in beforeItems[i])
            {
                itemGraph[before].Add(i);
                itemIndegree[i]++;

                int g1 = group[i];
                int g2 = group[before];

                if (g1 != g2 && !groupGraph[g2].Contains(g1))
                {
                    groupGraph[g2].Add(g1);
                    groupIndegree[g1]++;
                }
            }
        }

        // Step 3: Topological sort groups and items
        var sortedGroups = TopoSort(groupGraph, groupIndegree, newGroupId);
        if (sortedGroups.Count == 0) return [];

        var sortedItems = TopoSort(itemGraph, itemIndegree, n);
        if (sortedItems.Count == 0) return [];

        // Step 4: Group items by group
        var groupToItems = new Dictionary<int, List<int>>();
        foreach (int item in sortedItems)
        {
            int g = group[item];
            if (!groupToItems.ContainsKey(g))
                groupToItems[g] = [];
            groupToItems[g].Add(item);
        }

        // Step 5: Flatten result using sorted group order
        var result = new List<int>();
        foreach (int g in sortedGroups)
        {
            if (groupToItems.ContainsKey(g))
                result.AddRange(groupToItems[g]);
        }

        return [.. result];
    }

    private List<int> TopoSort(Dictionary<int, List<int>> graph, int[] indegree, int total)
    {
        var result = new List<int>();
        var queue = new Queue<int>();

        for (int i = 0; i < total; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            result.Add(node);
            foreach (var neighbor in graph[node])
            {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        return result.Count == total ? result : new List<int>(); // return empty if cycle
    }
}
