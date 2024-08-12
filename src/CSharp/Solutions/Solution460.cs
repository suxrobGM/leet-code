using System.Text;

namespace LeetCode.Solutions;

public class Solution460
{
    /// <summary>
    /// 460. LFU Cache - Hard
    /// <a href="https://leetcode.com/problems/lfu-cache">See the problem</a>
    /// </summary>
    public class LFUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, int> _values = [];
        private readonly Dictionary<int, int> _frequencies = [];
        private readonly Dictionary<int, LinkedList<int>> _frequencyLists = [];
        private int _minFrequency;

        public LFUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_values.ContainsKey(key))
            {
                return -1;
            }

            var frequency = _frequencies[key];
            _frequencies[key] = frequency + 1;
            _frequencyLists[frequency].Remove(key);

            if (frequency == _minFrequency && _frequencyLists[frequency].Count == 0)
            {
                _minFrequency++;
            }

            if (!_frequencyLists.ContainsKey(frequency + 1))
            {
                _frequencyLists[frequency + 1] = new LinkedList<int>();
            }

            _frequencyLists[frequency + 1].AddLast(key);

            return _values[key];
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0)
            {
                return;
            }

            if (_values.ContainsKey(key))
            {
                _values[key] = value;
                Get(key);
                return;
            }

            if (_values.Count == _capacity)
            {
                var removedKey = _frequencyLists[_minFrequency].First.Value;
                _values.Remove(removedKey);
                _frequencies.Remove(removedKey);
                _frequencyLists[_minFrequency].RemoveFirst();
            }

            _values[key] = value;
            _frequencies[key] = 1;
            _minFrequency = 1;

            if (!_frequencyLists.ContainsKey(1))
            {
                _frequencyLists[1] = new LinkedList<int>();
            }

            _frequencyLists[1].AddLast(key);
        }
    }
}
