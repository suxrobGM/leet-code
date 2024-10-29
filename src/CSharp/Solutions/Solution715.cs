using System.Text;

namespace LeetCode.Solutions;

public class Solution715
{
    /// <summary>
    /// 715. Range Module - Hard
    /// <a href="https://leetcode.com/problems/range-module">See the problem</a>
    /// </summary>
    public class RangeModule
    {
        private SortedDictionary<int, int> intervals = [];

        public void AddRange(int left, int right)
        {
            int toAddLeft = left;
            int toAddRight = right;

            // Collect overlapping intervals' keys
            var overlaps = new List<int>();
            foreach (var kvp in intervals)
            {
                int start = kvp.Key;
                int end = kvp.Value;

                if (end < left) continue; // No overlap on the left
                if (start > right) break; // No overlap on the right

                toAddLeft = Math.Min(toAddLeft, start);
                toAddRight = Math.Max(toAddRight, end);
                overlaps.Add(start); // Mark the interval for removal
            }

            // Remove all overlapping intervals outside of the loop
            foreach (var start in overlaps)
            {
                intervals.Remove(start);
            }

            // Insert the new merged interval
            intervals[toAddLeft] = toAddRight;
        }

        public bool QueryRange(int left, int right)
        {
            // Look for an interval that completely covers [left, right)
            foreach (var kvp in intervals)
            {
                int start = kvp.Key;
                int end = kvp.Value;
                if (start > left) break;  // Stop if intervals go beyond the query
                if (left >= start && right <= end)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveRange(int left, int right)
        {
            // Collect overlapping intervals' keys
            var overlaps = new List<int>();
            foreach (var kvp in intervals)
            {
                int start = kvp.Key;
                int end = kvp.Value;

                if (end <= left) continue; // No overlap on the left
                if (start >= right) break; // No overlap on the right

                overlaps.Add(start); // Mark the interval for removal

                // Handle left side of the overlapping interval if needed
                if (start < left)
                {
                    intervals[start] = left;  // Trim the interval from the right to `left`
                }

                // Handle right side of the overlapping interval if needed
                if (end > right)
                {
                    intervals[right] = end;  // Trim the interval from the left to `right`
                }
            }

            // Remove the fully overlapping intervals outside of the loop
            foreach (var start in overlaps)
            {
                intervals.Remove(start);
            }
        }
    }
}
