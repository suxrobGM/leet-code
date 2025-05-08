using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1334
{
    /// <summary>
    /// 1334. Find the City With the Smallest Number of Neighbors at a Threshold Distance - Medium
    /// <a href="https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance">See the problem</a>
    /// </summary>
    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
    {
        var dist = new int[n, n];
        int INF = 10001;

        // Initialize distance matrix
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                dist[i, j] = (i == j) ? 0 : INF;

        // Set initial edges
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            dist[u, v] = w;
            dist[v, u] = w;
        }

        // Floyd-Warshall to compute shortest paths
        for (int k = 0; k < n; k++)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                        dist[i, j] = dist[i, k] + dist[k, j];

        int minReachable = n;
        int resultCity = -1;

        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (i != j && dist[i, j] <= distanceThreshold)
                    count++;
            }

            // Prefer the city with higher index in case of tie
            if (count <= minReachable)
            {
                minReachable = count;
                resultCity = i;
            }
        }

        return resultCity;
    }
}
