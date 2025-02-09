using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution981
{
    /// <summary>
    /// 981. Time Based Key-Value Store - Medium
    /// <a href="https://leetcode.com/problems/time-based-key-value-store">See the problem</a>
    /// </summary>
    public class TimeMap
    {
        private readonly Dictionary<string, List<(int timestamp, string value)>> _map = [];

        public void Set(string key, string value, int timestamp)
        {
            if (!_map.ContainsKey(key))
            {
                _map[key] = new List<(int timestamp, string value)>();
            }

            _map[key].Add((timestamp, value));
        }

        public string Get(string key, int timestamp)
        {
            if (!_map.ContainsKey(key))
            {
                return string.Empty;
            }

            var values = _map[key];
            var left = 0;
            var right = values.Count - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (values[mid].timestamp == timestamp)
                {
                    return values[mid].value;
                }
                else if (values[mid].timestamp < timestamp)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return right >= 0 ? values[right].value : string.Empty;
        }
    }
}
