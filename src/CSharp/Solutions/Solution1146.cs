using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1146
{
    /// <summary>
    /// 1146. Snapshot Array - Medium
    /// <a href="https://leetcode.com/problems/snapshot-array">See the problem</a>
    /// </summary>
    public class SnapshotArray
    {
        private Dictionary<int, List<(int snapId, int value)>> data;
        private int snapId;

        public SnapshotArray(int length)
        {
            data = [];
            snapId = 0;
        }

        public void Set(int index, int val)
        {
            if (!data.ContainsKey(index))
            {
                data[index] = [];
            }

            // Update value for current snap_id if already added
            if (data[index].Count > 0 && data[index][data[index].Count - 1].snapId == snapId)
            {
                data[index][data[index].Count - 1] = (snapId, val);
            }
            else
            {
                data[index].Add((snapId, val));
            }
        }

        public int Snap()
        {
            return snapId++;
        }

        public int Get(int index, int snap_id)
        {
            if (!data.ContainsKey(index)) return 0;

            var values = data[index];

            // Binary Search to find the correct snapshot value
            int left = 0, right = values.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (values[mid].snapId <= snap_id)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            // The closest valid value is at 'right' position
            return right >= 0 ? values[right].value : 0;
        }
    }
}
