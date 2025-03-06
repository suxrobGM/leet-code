using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1051
{
    /// <summary>
    /// 1051. Height Checker - Easy
    /// <a href="https://leetcode.com/problems/height-checker</a>
    /// </summary>
    public int HeightChecker(int[] heights)
    {
        var sorted = new int[heights.Length];
        heights.CopyTo(sorted, 0);
        Array.Sort(sorted);

        var count = 0;
        for (var i = 0; i < heights.Length; i++)
        {
            if (heights[i] != sorted[i])
            {
                count++;
            }
        }

        return count;
    }
}
