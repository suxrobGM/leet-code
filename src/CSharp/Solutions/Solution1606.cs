using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1606
{
    /// <summary>
    /// 1606. Find Servers That Handled Most Number of Requests - Hard
    /// <a href="https://leetcode.com/problems/find-servers-that-handled-most-number-of-requests">See the problem</a>
    /// </summary>
    public IList<int> BusiestServers(int k, int[] arrival, int[] load)
    {
        var result = new List<int>();
        var serverLoads = new int[k];

        // PriorityQueue: (endTime, serverId)
        var busyServers = new PriorityQueue<(int endTime, int serverId), int>();

        // Available servers stored as a sorted set
        var availableServers = new SortedSet<int>(Enumerable.Range(0, k));

        for (int i = 0; i < arrival.Length; i++)
        {
            int currTime = arrival[i];
            int duration = load[i];

            // Free up servers that have completed their jobs
            while (busyServers.Count > 0 && busyServers.Peek().endTime <= currTime)
            {
                var (endTime, sid) = busyServers.Dequeue();
                availableServers.Add(sid);
            }

            if (availableServers.Count == 0)
                continue; // drop the request

            int preferred = i % k;

            int server;
            var view = availableServers.GetViewBetween(preferred, k - 1);
            if (view.Count > 0)
                server = view.Min;
            else
                server = availableServers.Min;

            availableServers.Remove(server);
            serverLoads[server]++;
            busyServers.Enqueue((currTime + duration, server), currTime + duration);
        }

        int maxRequests = serverLoads.Max();

        for (int i = 0; i < k; i++)
        {
            if (serverLoads[i] == maxRequests)
                result.Add(i);
        }

        return result;
    }
}
