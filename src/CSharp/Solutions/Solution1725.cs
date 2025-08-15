using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1725
{
    /// <summary>
    /// 1725. Number Of Rectangles That Can Form The Largest Square - Easy
    /// <a href="https://leetcode.com/problems/number-of-rectangles-that-can-form-the-largest-square">See the problem</a>
    /// </summary>
    public int CountGoodRectangles(int[][] rectangles)
    {
        int maxLen = 0;
        int count = 0;

        foreach (var rect in rectangles)
        {
            int minSide = Math.Min(rect[0], rect[1]);
            if (minSide > maxLen)
            {
                maxLen = minSide;
                count = 1;
            }
            else if (minSide == maxLen)
            {
                count++;
            }
        }

        return count;
    }
}
