using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution855
{
    /// <summary>
    /// 855. Exam Room - Medium
    /// <a href="https://leetcode.com/problems/exam-room">See the problem</a>
    /// </summary>
    public class ExamRoom
    {
        private readonly int n;
        private readonly SortedSet<int> seats = [];

        public ExamRoom(int n)
        {
            this.n = n;
        }

        public int Seat()
        {
            if (seats.Count == 0)
            {
                seats.Add(0);
                return 0;
            }

            var maxDistance = seats.Min;
            var start = 0;
            var end = 0;
            foreach (var seat in seats)
            {
                var distance = (seat - start) / 2;
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    end = start + distance;
                }

                start = seat;
            }

            if (n - 1 - seats.Max > maxDistance)
            {
                end = n - 1;
            }

            seats.Add(end);
            return end;
        }

        public void Leave(int p)
        {
            seats.Remove(p);
        }
    }
}
