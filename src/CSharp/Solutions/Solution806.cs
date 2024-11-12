using System.Text;

namespace LeetCode.Solutions;

public class Solution806
{
    /// <summary>
    /// 806. Number of Lines To Write String - Easy
    /// <a href="https://leetcode.com/problems/number-of-lines-to-write-string">See the problem</a>
    /// </summary>
    public int[] NumberOfLines(int[] widths, string s)
    {
        var lines = 1;
        var width = 0;

        foreach (var c in s)
        {
            var w = widths[c - 'a'];

            if (width + w > 100)
            {
                lines++;
                width = w;
            }
            else
            {
                width += w;
            }
        }

        return [lines, width];
    }
}
