using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1227
{
    /// <summary>
    /// 1227. Airplane Seat Assignment Probability - Medium
    /// <a href="https://leetcode.com/problems/airplane-seat-assignment-probability">See the problem</a>
    /// </summary>
    public double NthPersonGetsNthSeat(int n)
    {
        // If there is only one seat, the first person will always sit in it.
        if (n == 1) return 1.0;

        // The probability that the last person gets their own seat is 0.5.
        return 0.5;
    }
}
