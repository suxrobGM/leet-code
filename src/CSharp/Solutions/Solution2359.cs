namespace LeetCode.Solutions;

public class Solution2359
{
    /// <summary>
    /// 2359. Find Closest Node to Given Two Nodes - Medium
    /// <a href="https://leetcode.com/problems/find-closest-node-to-given-two-nodes">See the problem</a>
    /// </summary>
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int[] distances1 = GetDistances(edges, node1);
        int[] distances2 = GetDistances(edges, node2);
        int meetingNode = -1;
        int bestDistance = int.MaxValue;

        // Scan in index order and keep the first node at each best distance.
        for (int node = 0; node < edges.Length; node++)
        {
            if (distances1[node] == -1 || distances2[node] == -1)
                continue;

            int distance = Math.Max(distances1[node], distances2[node]);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                meetingNode = node;
            }
        }

        return meetingNode;
    }

    private static int[] GetDistances(int[] edges, int start)
    {
        int[] distances = new int[edges.Length];
        Array.Fill(distances, -1);

        int node = start;
        int distance = 0;
        while (node != -1 && distances[node] == -1)
        {
            distances[node] = distance++;
            node = edges[node];
        }

        return distances;
    }
}
