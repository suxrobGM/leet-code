using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1904
{
    /// <summary>
    /// 1904. The Number of Full Rounds You Have Played - Medium
    /// <a href="https://leetcode.com/problems/the-number-of-full-rounds-you-have-played">See the problem</a>
    /// </summary>
    public int NumberOfRounds(string loginTime, string logoutTime)
    {
        int startHour = int.Parse(loginTime.Substring(0, 2));
        int startMinute = int.Parse(loginTime.Substring(3, 2));
        int endHour = int.Parse(logoutTime.Substring(0, 2));
        int endMinute = int.Parse(logoutTime.Substring(3, 2));

        int startTotalMinutes = startHour * 60 + startMinute;
        int endTotalMinutes = endHour * 60 + endMinute;

        // If logout time is earlier than login time, it means the session went past midnight
        if (endTotalMinutes < startTotalMinutes)
        {
            endTotalMinutes += 24 * 60; // Add 24 hours in minutes
        }

        // Round up the start time to the next quarter hour
        if (startTotalMinutes % 15 != 0)
        {
            startTotalMinutes += 15 - (startTotalMinutes % 15);
        }

        // Round down the end time to the previous quarter hour
        endTotalMinutes -= endTotalMinutes % 15;

        // Calculate the number of full rounds
        int fullRounds = Math.Max(0, (endTotalMinutes - startTotalMinutes) / 15);

        return fullRounds;
    }
}
