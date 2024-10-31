using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution732
{
    /// <summary>
    /// 732. My Calendar III - Hard
    /// <a href="https://leetcode.com/problems/my-calendar-iii">See the problem</a>
    /// </summary>

    public class MyCalendarThree
    {
        private readonly List<(int start, int end)> _bookings = [];
        private readonly Dictionary<int, int> _events = [];

        public int Book(int start, int end)
        {
            _events[start] = _events.GetValueOrDefault(start, 0) + 1;
            _events[end] = _events.GetValueOrDefault(end, 0) - 1;

            var active = 0;
            var max = 0;

            foreach (var (_, delta) in _events.OrderBy(e => e.Key))
            {
                active += delta;
                max = Math.Max(max, active);
            }

            return max;
        }
    }
}
