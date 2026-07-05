namespace LeetCode.Solutions;

public class Solution2194
{
    /// <summary>
    /// 2194. Cells in a Range on an Excel Sheet - Easy
    /// <a href="https://leetcode.com/problems/cells-in-a-range-on-an-excel-sheet">See the problem</a>
    /// </summary>
    public IList<string> CellsInRange(string s)
    {
        var result = new List<string>();
        var parts = s.Split(':');
        var start = parts[0];
        var end = parts[1];

        var startCol = start[0];
        var startRow = int.Parse(start.Substring(1));
        var endCol = end[0];
        var endRow = int.Parse(end.Substring(1));

        for (var col = startCol; col <= endCol; col++)
        {
            for (var row = startRow; row <= endRow; row++)
            {
                result.Add($"{col}{row}");
            }
        }

        return result;
    }
}
