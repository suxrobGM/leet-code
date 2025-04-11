using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1232
{
    /// <summary>
    /// 1232. Check If It Is a Straight Line - Easy
    /// <a href="https://leetcode.com/problems/check-if-it-is-a-straight-line">See the problem</a>
    /// </summary>
    public bool CheckStraightLine(int[][] coordinates)
    {
        if (coordinates.Length < 2) return false;

        // Calculate the slope using the first two points
        int x0 = coordinates[0][0], y0 = coordinates[0][1];
        int x1 = coordinates[1][0], y1 = coordinates[1][1];

        // Check if all points are on the same line
        for (int i = 2; i < coordinates.Length; i++)
        {
            int x = coordinates[i][0], y = coordinates[i][1];
            if ((y - y0) * (x1 - x0) != (y1 - y0) * (x - x0))
                return false;
        }

        return true;
    }
}
