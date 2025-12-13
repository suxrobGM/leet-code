using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1942
{
    /// <summary>
    /// 1942. The Number of the Smallest Unoccupied Chair - Medium
    /// <a href="https://leetcode.com/problems/the-number-of-the-smallest-unoccupied-chair">See the problem</a>
    /// </summary>
    public int SmallestChair(int[][] times, int targetFriend)
    {
        int n = times.Length;

        // Create events: (time, type, friend_id)
        // type: 0 = departure, 1 = arrival
        List<(int time, int type, int friendId)> events = new List<(int, int, int)>();

        for (int i = 0; i < n; i++)
        {
            events.Add((times[i][0], 1, i)); // arrival
            events.Add((times[i][1], 0, i)); // departure
        }

        // Sort by time, then by type (departures before arrivals at same time)
        events.Sort((a, b) =>
        {
            if (a.time != b.time) return a.time.CompareTo(b.time);
            return a.type.CompareTo(b.type); // 0 (departure) before 1 (arrival)
        });

        // Min heap for available chairs
        var availableChairs = new PriorityQueue<int, int>();

        // Track which chair each friend is sitting on
        int[] chairAssignment = new int[n];
        Array.Fill(chairAssignment, -1);

        // Track which chairs are currently occupied
        var occupiedChairs = new HashSet<int>();

        foreach (var (time, type, friendId) in events)
        {
            if (type == 0)
            {
                // Departure: friend leaves, chair becomes available
                int chair = chairAssignment[friendId];
                occupiedChairs.Remove(chair);
                availableChairs.Enqueue(chair, chair);
            }
            else
            {
                // Arrival: friend arrives and needs a chair
                int chair;

                // Clean up heap - remove chairs that are still occupied
                while (availableChairs.Count > 0 && occupiedChairs.Contains(availableChairs.Peek()))
                {
                    availableChairs.Dequeue();
                }

                // Get smallest available chair
                if (availableChairs.Count > 0)
                {
                    chair = availableChairs.Dequeue();
                }
                else
                {
                    // Find smallest unoccupied chair starting from 0
                    chair = 0;
                    while (occupiedChairs.Contains(chair))
                    {
                        chair++;
                    }
                }

                occupiedChairs.Add(chair);
                chairAssignment[friendId] = chair;

                // Return immediately when target friend arrives
                if (friendId == targetFriend)
                {
                    return chair;
                }
            }
        }

        return -1; // Should never reach here
    }
}
