namespace LeetCode.Solutions;

public class Solution381
{
    /// <summary>
    /// 381. Insert Delete GetRandom O(1) - Duplicates allowed - Hard
    /// <a href="https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed">See the problem</a>
    /// </summary>
    public class RandomizedCollection
    {
        private readonly Dictionary<int, HashSet<int>> _indexes;
        private readonly List<int> _values;
        private readonly Random _random;

        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            _indexes = [];
            _values = [];
            _random = new Random();
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (!_indexes.ContainsKey(val))
            {
                _indexes[val] = new HashSet<int>();
            }

            _indexes[val].Add(_values.Count);
            _values.Add(val);

            return _indexes[val].Count == 1;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (!_indexes.ContainsKey(val) || _indexes[val].Count == 0)
            {
                return false;
            }

            var index = _indexes[val].First();
            _indexes[val].Remove(index);

            if (index != _values.Count - 1)
            {
                var lastValue = _values[^1];
                _values[index] = lastValue;
                _indexes[lastValue].Remove(_values.Count - 1);
                _indexes[lastValue].Add(index);
            }

            _values.RemoveAt(_values.Count - 1);

            return true;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            return _values[_random.Next(_values.Count)];
        }
    }
}
