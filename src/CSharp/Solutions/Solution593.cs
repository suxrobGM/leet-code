namespace LeetCode.Solutions;

public class Solution593
{
    /// <summary>
    /// 593. Valid Square - Medium
    /// <a href="https://leetcode.com/problems/valid-square">See the problem</a>
    /// </summary>
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
    {
        var points = new[] { p1, p2, p3, p4 };
        Array.Sort(points, (a, b) =>
        {
            if (a[0] == b[0])
            {
                return a[1] - b[1];
            }
            return a[0] - b[0];
        });
        return Distance(points[0], points[1]) > 0
            && Distance(points[0], points[1]) == Distance(points[1], points[3])
            && Distance(points[1], points[3]) == Distance(points[3], points[2])
            && Distance(points[3], points[2]) == Distance(points[2], points[0])
            && Distance(points[0], points[3]) == Distance(points[1], points[2]);
    }

    private int Distance(int[] p1, int[] p2)
    {
        return (p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1]);
    }
}
