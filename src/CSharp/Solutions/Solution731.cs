using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution731
{
    /// <summary>
    /// 731. My Calendar II - Medium
    /// <a href="https://leetcode.com/problems/my-calendar-ii">See the problem</a>
    /// </summary>

    public class MyCalendarTwo
    {
        private readonly List<(int start, int end)> _bookings = [];
        private readonly List<(int start, int end)> _overlaps = [];

        public bool Book(int start, int end)
        {
            foreach (var (s, e) in _overlaps)
            {
                if (start < e && end > s)
                {
                    return false;
                }
            }

            foreach (var (s, e) in _bookings)
            {
                if (start < e && end > s)
                {
                    _overlaps.Add((Math.Max(start, s), Math.Min(end, e)));
                }
            }

            _bookings.Add((start, end));
            return true;
        }
    }
}
