using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution519
{
    /// <summary>
    /// 519. Random Flip Matrix - Medium
    /// <a href="https://leetcode.com/problems/random-flip-matrix">See the problem</a>
    /// </summary>
    public class Solution
    {
        private readonly int _rows;
        private readonly int _cols;
        private int _total;
        private readonly Dictionary<int, int> _map;
        private readonly Random _random;

        public Solution(int n_rows, int n_cols)
        {
            _rows = n_rows;
            _cols = n_cols;
            _total = n_rows * n_cols;
            _map = new Dictionary<int, int>();
            _random = new Random();
        }

        public int[] Flip()
        {
            var r = _random.Next(_total--);
            var x = _map.TryGetValue(r, out var value) ? value : r;
            _map[r] = _map.TryGetValue(_total, out var temp) ? temp : _total;
            return new[] {x / _cols, x % _cols};
        }

        public void Reset()
        {
            _total = _rows * _cols;
            _map.Clear();
        }
    }
}
