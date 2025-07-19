using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1642
{
    /// <summary>
    /// 1642. Furthest Building You Can Reach - Medium
    /// <a href="https://leetcode.com/problems/furthest-building-you-can-reach">See the problem</a>
    /// </summary>
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        // Min-heap to track the biggest climbs (we use bricks on the smallest ones)
        PriorityQueue<int, int> minHeap = new();

        for (int i = 0; i < heights.Length - 1; i++)
        {
            int climb = heights[i + 1] - heights[i];
            if (climb > 0)
            {
                minHeap.Enqueue(climb, climb);

                // If we used more ladders than available, use bricks on smallest climb
                if (minHeap.Count > ladders)
                {
                    int min = minHeap.Dequeue();
                    bricks -= min;
                    if (bricks < 0)
                        return i;
                }
            }
        }

        return heights.Length - 1;
    }
}
