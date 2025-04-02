using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1185
{
    /// <summary>
    /// 1185. Day of the Week - Easy
    /// <a href="https://leetcode.com/problems/day-of-the-week">See the problem</a>
    /// </summary>
    public string DayOfTheWeek(int day, int month, int year)
    {
        var date = new DateTime(year, month, day);
        return date.ToString("dddd", System.Globalization.CultureInfo.InvariantCulture);
    }
}
