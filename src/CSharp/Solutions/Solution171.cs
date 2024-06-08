namespace LeetCode.Solutions;

public class Solution171
{
    /// <summary>
    /// 171. Excel Sheet Column Number - Easy
    /// <a href="https://leetcode.com/problems/excel-sheet-column-number">See the problem</a>
    /// </summary>
    public int TitleToNumber(string columnTitle)
    {
        var result = 0;

        foreach (var ch in columnTitle)
        {
            result = result * 26 + ch - 'A' + 1;
        }

        return result;
    }
}
