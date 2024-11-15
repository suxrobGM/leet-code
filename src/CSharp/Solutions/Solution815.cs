using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution815
{
    /// <summary>
    /// 815. Bus Routes - Hard
    /// <a href="https://leetcode.com/problems/bus-routes">See the problem</a>
    /// </summary>
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        if (source == target) return 0;

        // Map stops to the list of routes containing them
        var stopToRoutes = new Dictionary<int, List<int>>();
        for (int i = 0; i < routes.Length; i++)
        {
            foreach (int stop in routes[i])
            {
                if (!stopToRoutes.ContainsKey(stop))
                {
                    stopToRoutes[stop] = new List<int>();
                }
                stopToRoutes[stop].Add(i);
            }
        }

        // If the source or target is not in any route, return -1
        if (!stopToRoutes.ContainsKey(source) || !stopToRoutes.ContainsKey(target))
        {
            return -1;
        }

        // BFS initialization
        var queue = new Queue<(int, int)>(); // (routeIndex, busCount)
        var visitedRoutes = new HashSet<int>();

        // Add all routes containing the source stop to the queue
        foreach (int route in stopToRoutes[source])
        {
            queue.Enqueue((route, 1));
            visitedRoutes.Add(route);
        }

        // Perform BFS
        while (queue.Count > 0)
        {
            var (currentRoute, busCount) = queue.Dequeue();

            // Check if this route contains the target
            foreach (int stop in routes[currentRoute])
            {
                if (stop == target)
                {
                    return busCount;
                }
            }

            // Add all neighboring routes
            foreach (int stop in routes[currentRoute])
            {
                foreach (int nextRoute in stopToRoutes[stop])
                {
                    if (!visitedRoutes.Contains(nextRoute))
                    {
                        queue.Enqueue((nextRoute, busCount + 1));
                        visitedRoutes.Add(nextRoute);
                    }
                }
            }
        }

        return -1; // Target is not reachable
    }
}
