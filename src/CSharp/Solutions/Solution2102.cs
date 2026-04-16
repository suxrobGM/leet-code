using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2102
{
    /// <summary>
    /// 2102. Sequentially Ordinal Rank Tracker - Hard
    /// <a href="https://leetcode.com/problems/sequentially-ordinal-rank-tracker">See the problem</a>
    /// </summary>
    public class SORTracker
    {
        private readonly PriorityQueue<(string Name, int Score), (string Name, int Score)> _above;
        private readonly PriorityQueue<(string Name, int Score), (string Name, int Score)> _below;

        public SORTracker()
        {
            var aboveComparer = Comparer<(string Name, int Score)>.Create((a, b) =>
            {
                if (a.Score != b.Score) return b.Score.CompareTo(a.Score);
                return string.CompareOrdinal(a.Name, b.Name);
            });
            var belowComparer = Comparer<(string Name, int Score)>.Create((a, b) =>
            {
                if (a.Score != b.Score) return a.Score.CompareTo(b.Score);
                return string.CompareOrdinal(b.Name, a.Name);
            });
            _above = new PriorityQueue<(string, int), (string, int)>(aboveComparer);
            _below = new PriorityQueue<(string, int), (string, int)>(belowComparer);
        }

        public void Add(string name, int score)
        {
            var loc = (name, score);
            _above.Enqueue(loc, loc);

            if (_below.Count > 0 && IsBetter(_above.Peek(), _below.Peek()))
            {
                var aboveTop = _above.Dequeue();
                var belowTop = _below.Dequeue();
                _above.Enqueue(belowTop, belowTop);
                _below.Enqueue(aboveTop, aboveTop);
            }
        }

        public string Get()
        {
            var top = _above.Dequeue();
            _below.Enqueue(top, top);
            return top.Name;
        }

        private static bool IsBetter((string Name, int Score) a, (string Name, int Score) b)
        {
            if (a.Score != b.Score) return a.Score > b.Score;
            return string.CompareOrdinal(a.Name, b.Name) < 0;
        }
    }
}
