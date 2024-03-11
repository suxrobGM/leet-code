namespace LeetCode.Solutions;

public class Solution452
{
    /// <summary>
    /// 452. Minimum Number of Arrows to Burst Balloons - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons">See the problem</a>
    /// </summary>
    public int FindMinArrowShots(int[][] points) 
    {
        if (points.Length == 0)
        {
            return 0;
        }
        
        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
        
        var arrows = 1;
        var end = points[0][1];
        
        for (var i = 1; i < points.Length; i++)
        {
            if (points[i][0] > end)
            {
                arrows++;
                end = points[i][1];
            }
        }
        
        return arrows;
    }
}
