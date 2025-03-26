using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1154
{
    /// <summary>
    /// 1154. Day of the Year - Easy
    /// <a href="https://leetcode.com/problems/day-of-the-year">See the problem</a>
    /// </summary>
    public int DayOfYear(string date)
    {
        var parts = date.Split('-');
        var year = int.Parse(parts[0]);
        var month = int.Parse(parts[1]);
        var day = int.Parse(parts[2]);

        var days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
        {
            days[1] = 29;
        }

        var result = 0;
        for (var i = 0; i < month - 1; i++)
        {
            result += days[i];
        }

        return result + day;
    }
}
