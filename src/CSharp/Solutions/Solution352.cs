using System.Text;

namespace LeetCode.Solutions;

public class Solution352
{
    /// <summary>
    /// 352. Data Stream as Disjoint Intervals - Hard
    /// <a href="https://leetcode.com/problems/data-stream-as-disjoint-intervals">See the problem</a>
    /// </summary>
    public class SummaryRanges
    {
        private readonly List<int[]> _intervals;

        public SummaryRanges()
        {
            _intervals = new List<int[]>();
        }

        public void AddNum(int val)
        {
            var newInterval = new int[] { val, val };
            var merged = new List<int[]>();

            var i = 0;
            while (i < _intervals.Count && _intervals[i][1] < newInterval[0] - 1)
            {
                merged.Add(_intervals[i]);
                i++;
            }

            while (i < _intervals.Count && _intervals[i][0] <= newInterval[1] + 1)
            {
                newInterval[0] = Math.Min(newInterval[0], _intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], _intervals[i][1]);
                i++;
            }

            merged.Add(newInterval);

            while (i < _intervals.Count)
            {
                merged.Add(_intervals[i]);
                i++;
            }

            _intervals.Clear();
            _intervals.AddRange(merged);
        }

        public int[][] GetIntervals()
        {
            return _intervals.ToArray();
        }
    }
}
