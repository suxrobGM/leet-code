using System.Text;

namespace LeetCode.Solutions;

public class Solution1845
{
    /// <summary>
    /// 1845. Seat Reservation Manager - Medium
    /// <a href="https://leetcode.com/problems/seat-reservation-manager">See the problem</a>
    /// </summary>
    public class SeatManager
    {
        private readonly SortedSet<int> _availableSeats;

        public SeatManager(int n)
        {
            _availableSeats = [];
            for (int i = 1; i <= n; i++)
            {
                _availableSeats.Add(i);
            }
        }

        public int Reserve()
        {
            int seatNumber = _availableSeats.Min;
            _availableSeats.Remove(seatNumber);
            return seatNumber;
        }

        public void Unreserve(int seatNumber)
        {
            _availableSeats.Add(seatNumber);
        }
    }
}
