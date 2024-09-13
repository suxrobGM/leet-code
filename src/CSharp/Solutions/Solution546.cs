using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution546
{
    /// <summary>
    /// 546. Remove Boxes - Hard
    /// <a href="https://leetcode.com/problems/remove-boxes">See the problem</a>
    /// </summary>
    public int RemoveBoxes(int[] boxes)
    {
        var dp = new int[100, 100, 100]; // DP memoization table
        return CalculatePoints(boxes, 0, boxes.Length - 1, 0, dp);
    }

    private int CalculatePoints(int[] boxes, int left, int right, int k, int[,,] dp)
    {
        if (left > right) return 0; // Base case: no boxes to remove
        if (dp[left, right, k] != 0) return dp[left, right, k]; // Return memoized result

        // Maximize points by removing the first block (boxes[left])
        // Increment k (because boxes[left] can be extended by boxes of the same color before it)
        int maxPoints = (k + 1) * (k + 1) + CalculatePoints(boxes, left + 1, right, 0, dp);

        // Try merging boxes[left] with some boxes of the same color later
        for (int m = left + 1; m <= right; m++)
        {
            if (boxes[m] == boxes[left])
            {
                // Calculate points by merging boxes[left:m] with the same color
                maxPoints = Math.Max(maxPoints,
                    CalculatePoints(boxes, left + 1, m - 1, 0, dp) +
                    CalculatePoints(boxes, m, right, k + 1, dp));
            }
        }

        dp[left, right, k] = maxPoints; // Memoize the result
        return maxPoints;
    }
}
