using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution332
{
    /// <summary>
    /// 332. Reconstruct Itinerary - Hard
    /// <a href="https://leetcode.com/problems/reconstruct-itinerary">See the problem</a>
    /// </summary>
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        var graph = new Dictionary<string, List<string>>();

        foreach (var ticket in tickets)
        {
            if (!graph.ContainsKey(ticket[0]))
            {
                graph[ticket[0]] = new List<string>();
            }

            graph[ticket[0]].Add(ticket[1]);
        }

        foreach (var list in graph.Values)
        {
            list.Sort();
        }

        var result = new List<string>();
        Dfs(graph, "JFK", result);

        return result;
    }

    private void Dfs(Dictionary<string, List<string>> graph, string from, List<string> result)
    {
        if (graph.ContainsKey(from))
        {
            var destinations = graph[from];

            while (destinations.Count > 0)
            {
                var to = destinations[0];
                destinations.RemoveAt(0);
                Dfs(graph, to, result);
            }
        }

        result.Insert(0, from);
    }
}
