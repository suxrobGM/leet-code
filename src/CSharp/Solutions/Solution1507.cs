using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1507
{
    /// <summary>
    /// 1507. Reformat Date - Easy
    /// <a href="https://leetcode.com/problems/reformat-date">See the problem</a>
    /// </summary>
    public string ReformatDate(string date)
    {
        // Split the date into components
        var parts = date.Split(' ');
        var day = parts[0].Substring(0, parts[0].Length - 2); // Remove the suffix (st, nd, rd, th)
        var month = parts[1];
        var year = parts[2];

        // Map month names to their numeric representations
        var monthMap = new Dictionary<string, string>
        {
            { "Jan", "01" },
            { "Feb", "02" },
            { "Mar", "03" },
            { "Apr", "04" },
            { "May", "05" },
            { "Jun", "06" },
            { "Jul", "07" },
            { "Aug", "08" },
            { "Sep", "09" },
            { "Oct", "10" },
            { "Nov", "11" },
            { "Dec", "12" }
        };

        // Format the date in YYYY-MM-DD format
        return $"{year}-{monthMap[month]}-{day.PadLeft(2, '0')}";
    }
}
