using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution836
{
    /// <summary>
    /// 836. Rectangle Overlap - Easy
    /// <a href="https://leetcode.com/problems/rectangle-overlap">See the problem</a>
    /// </summary>
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        return rec1[0] < rec2[2] && rec1[1] < rec2[3] && rec1[2] > rec2[0] && rec1[3] > rec2[1];
    }
}
