namespace LeetCode.Solutions;

public class Solution2276
{
    /// <summary>
    /// 2276. Count Integers in Intervals - Hard
    /// <a href="https://leetcode.com/problems/count-integers-in-intervals">See the problem</a>
    /// </summary>
    public class CountIntervals
    {
        private readonly SortedSet<(int Start, int End)> _intervals = [];
        private int _count;

        public CountIntervals()
        {
        }

        public void Add(int left, int right)
        {
            while (_intervals.Count > 0)
            {
                // Every interval that touches or overlaps [left, right] starts at or before right + 1,
                // so the merge candidates are always the greatest interval of that view.
                var candidates = _intervals.GetViewBetween((0, 0), (right + 1, int.MaxValue));
                var last = candidates.Max;

                // Starts are at least 1, so the default tuple means the view is empty.
                if (last.Start == 0 || last.End < left - 1)
                {
                    break;
                }

                left = Math.Min(left, last.Start);
                right = Math.Max(right, last.End);
                _count -= last.End - last.Start + 1;
                _intervals.Remove(last);
            }

            _intervals.Add((left, right));
            _count += right - left + 1;
        }

        public int Count()
        {
            return _count;
        }
    }
}
