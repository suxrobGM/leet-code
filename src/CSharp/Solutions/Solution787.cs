using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution787
{
    /// <summary>
    /// 787. Cheapest Flights Within K Stops - Medium
    /// <a href="https://leetcode.com/problems/cheapest-flights-within-k-stops">See the problem</a>
    /// </summary>
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        // Create an adjacency list for the graph
        var graph = new Dictionary<int, List<(int to, int price)>>();
        foreach (var flight in flights)
        {
            if (!graph.ContainsKey(flight[0]))
            {
                graph[flight[0]] = new List<(int to, int price)>();
            }
            graph[flight[0]].Add((flight[1], flight[2]));
        }

        // Priority queue to store (cost, current city, stops)
        var pq = new PriorityQueue<(int cost, int city, int stops), int>();
        pq.Enqueue((0, src, 0), 0);

        // Dictionary to store the minimum cost to reach each city with a certain number of stops
        var minCost = new Dictionary<(int city, int stops), int>();

        while (pq.Count > 0)
        {
            var (currentCost, currentCity, currentStops) = pq.Dequeue();

            // If we reached the destination, return the cost
            if (currentCity == dst)
            {
                return currentCost;
            }

            // If we have made more than k stops, continue
            if (currentStops > k)
            {
                continue;
            }

            // Explore the neighbors
            if (graph.ContainsKey(currentCity))
            {
                foreach (var (nextCity, price) in graph[currentCity])
                {
                    int newCost = currentCost + price;
                    if (!minCost.ContainsKey((nextCity, currentStops + 1)) || newCost < minCost[(nextCity, currentStops + 1)])
                    {
                        minCost[(nextCity, currentStops + 1)] = newCost;
                        pq.Enqueue((newCost, nextCity, currentStops + 1), newCost);
                    }
                }
            }
        }

        // If we cannot reach the destination within k stops, return -1
        return -1;
    }
}
