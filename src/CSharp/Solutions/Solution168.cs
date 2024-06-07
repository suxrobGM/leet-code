using System.Text;

namespace LeetCode.Solutions;

public class Solution168
{
    /// <summary>
    /// 168. Excel Sheet Column Title - Easy
    /// <a href="https://leetcode.com/problems/excel-sheet-column-title">See the problem</a>
    /// </summary>
    public string ConvertToTitle(int columnNumber)
    {
        var result = new StringBuilder();

        while (columnNumber > 0)
        {
            columnNumber--;
            result.Insert(0, (char)('A' + columnNumber % 26));
            columnNumber /= 26;
        }

        return result.ToString();
    }
}
