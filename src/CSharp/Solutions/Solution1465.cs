using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1465
{
    /// <summary>
    /// 1465. Maximum Area of a Piece of Cake After Horizontal and Vertical Cuts - Medium
    /// <a href="https://leetcode.com/problems/maximum-area-of-a-piece-of-cake-after-horizontal-and-vertical-cuts">See the problem</a>
    /// </summary>
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
    {
        // Sort the cuts
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);

        // Add the edges of the cake to the cuts
        int maxH = Math.Max(horizontalCuts[0], h - horizontalCuts[^1]);
        int maxW = Math.Max(verticalCuts[0], w - verticalCuts[^1]);

        // Find the maximum distance between consecutive cuts
        for (int i = 1; i < horizontalCuts.Length; i++)
            maxH = Math.Max(maxH, horizontalCuts[i] - horizontalCuts[i - 1]);

        for (int i = 1; i < verticalCuts.Length; i++)
            maxW = Math.Max(maxW, verticalCuts[i] - verticalCuts[i - 1]);

        // Return the area of the largest piece of cake
        return (int)((long)maxH * maxW % 1000000007);
    }
}
