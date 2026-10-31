namespace LeetCode.Solutions;

public class Solution2336
{
    /// <summary>
    /// 2336. Smallest Number in Infinite Set - Medium
    /// <a href="https://leetcode.com/problems/smallest-number-in-infinite-set">See the problem</a>
    /// </summary>
    public class SmallestInfiniteSet
    {
        private readonly SortedSet<int> _addedBack;
        private int _nextSmallest;

        public SmallestInfiniteSet()
        {
            _addedBack = [];
            _nextSmallest = 1;
        }

        public int PopSmallest()
        {
            if (_addedBack.Count > 0)
            {
                int smallest = _addedBack.Min;
                _addedBack.Remove(smallest);
                return smallest;
            }

            // All numbers at or above this boundary are still in the set.
            return _nextSmallest++;
        }

        public void AddBack(int num)
        {
            if (num < _nextSmallest)
            {
                _addedBack.Add(num);
            }
        }
    }
}
