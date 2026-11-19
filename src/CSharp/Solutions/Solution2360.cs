namespace LeetCode.Solutions;

public class Solution2360
{
    /// <summary>
    /// 2360. Longest Cycle in a Graph - Hard
    /// <a href="https://leetcode.com/problems/longest-cycle-in-a-graph">See the problem</a>
    /// </summary>
    public int LongestCycle(int[] edges)
    {
        int[] visitTime = new int[edges.Length];
        int time = 1;
        int longestCycle = -1;

        for (int start = 0; start < edges.Length; start++)
        {
            if (visitTime[start] != 0)
                continue;

            int traversalStartTime = time;
            int node = start;
            while (node != -1 && visitTime[node] == 0)
            {
                visitTime[node] = time++;
                node = edges[node];
            }

            // A timestamp from this traversal marks the start of the cycle.
            if (node != -1 && visitTime[node] >= traversalStartTime)
                longestCycle = Math.Max(longestCycle, time - visitTime[node]);
        }

        return longestCycle;
    }
}
