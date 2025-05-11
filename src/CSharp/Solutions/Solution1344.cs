using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1344
{
    /// <summary>
    /// 1344. Angle Between Hands of a Clock - Medium
    /// <a href="https://leetcode.com/problems/angle-between-hands-of-a-clock">See the problem</a>
    /// </summary>
    public double AngleClock(int hour, int minutes)
    {
        // Normalize the hour to a 12-hour format
        hour %= 12;

        // Calculate the angles of the hour and minute hands
        double hourAngle = (hour + minutes / 60.0) * 30; // 360 degrees / 12 hours = 30 degrees per hour
        double minuteAngle = minutes * 6; // 360 degrees / 60 minutes = 6 degrees per minute

        // Calculate the absolute difference between the two angles
        double angle = Math.Abs(hourAngle - minuteAngle);

        // The angle between the hands should be the smaller of the two possible angles
        return Math.Min(angle, 360 - angle);
    }
}
