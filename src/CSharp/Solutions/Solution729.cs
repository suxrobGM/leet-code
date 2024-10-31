using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution729
{
    /// <summary>
    /// 729. My Calendar I - Medium
    /// <a href="https://leetcode.com/problems/my-calendar-i">See the problem</a>
    /// </summary>
    public class MyCalendar
    {
        private readonly List<(int start, int end)> _bookings = new();

        public bool Book(int start, int end)
        {
            foreach (var (s, e) in _bookings)
            {
                if (start < e && end > s)
                {
                    return false;
                }
            }

            _bookings.Add((start, end));
            return true;
        }
    }
}
