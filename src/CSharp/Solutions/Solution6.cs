using System.Text;

namespace LeetCode.Solutions;

public class Solution6
{
    /// <summary>
    /// 6. Zigzag Conversion - Medium
    /// <a href="https://leetcode.com/problems/zigzag-conversion/">See the problem</a>
    /// </summary>
    /// <remarks>Best case O(n), worst case O(n^3)</remarks>
    public string Convert(string s, int numRows) {
        if (numRows == 1)
        {
            return s;
        }

        var sb = new StringBuilder[numRows];
        var curRow = 0;
        var goingDown = false;

        for (var i = 0; i < sb.Length; i++)
        {
            sb[i] = new StringBuilder();
        }

        foreach (var @char in s)
        {
            sb[curRow].Append(@char);
            if (curRow == 0 || curRow == numRows - 1)
            {
                goingDown = !goingDown;
            }
                
            curRow += goingDown ? 1 : -1;
        }

        return string.Join<StringBuilder>("", sb);
    }
}
