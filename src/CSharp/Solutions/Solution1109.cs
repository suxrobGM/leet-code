using System.Text;

namespace LeetCode.Solutions;

public class Solution1109
{
    /// <summary>
    /// 1109. Corporate Flight Bookings - Medium
    /// <a href="https://leetcode.com/problems/corporate-flight-bookings">See the problem</a>
    /// </summary>
    public int[] CorpFlightBookings(int[][] bookings, int n)
    {
        var result = new int[n];
        foreach (var booking in bookings)
        {
            var first = booking[0] - 1;
            var last = booking[1] - 1;
            var seats = booking[2];
            result[first] += seats;
            if (last + 1 < n)
            {
                result[last + 1] -= seats;
            }
        }
        for (var i = 1; i < n; i++)
        {
            result[i] += result[i - 1];
        }
        return result;
    }
}
