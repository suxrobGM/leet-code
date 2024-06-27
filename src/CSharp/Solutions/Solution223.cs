namespace LeetCode.Solutions;

public class Solution223
{
    /// <summary>
    /// 223. Rectangle Area - Medium
    /// <a href="https://leetcode.com/problems/rectangle-area">See the problem</a>
    /// </summary>
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
    {
        var areaA = (ax2 - ax1) * (ay2 - ay1);
        var areaB = (bx2 - bx1) * (by2 - by1);

        var overlapWidth = Math.Max(0, Math.Min(ax2, bx2) - Math.Max(ax1, bx1));
        var overlapHeight = Math.Max(0, Math.Min(ay2, by2) - Math.Max(ay1, by1));
        var overlapArea = overlapWidth * overlapHeight;

        return areaA + areaB - overlapArea;
    }
}
