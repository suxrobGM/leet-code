namespace LeetCode.Solutions;

public class Solution284
{
    /// <summary>
    /// 284. Peeking Iterator - Medium
    /// <a href="https://leetcode.com/problems/peeking-iterator">See the problem</a>
    /// </summary>
    public class PeekingIterator
    {
        private readonly IEnumerator<int> _enumerator;

        public PeekingIterator(IEnumerator<int> enumerator)
        {
            _enumerator = enumerator;
        }

        public int Peek() => _enumerator.Current;

        public int Next()
        {
            var result = _enumerator.Current;
            _enumerator.MoveNext();
            return result;
        }

        public bool HasNext() => _enumerator.Current != 0;
    }
}
