using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1472
{
    /// <summary>
    /// 1472. Design Browser History - Medium
    /// <a href="https://leetcode.com/problems/design-browser-history">See the problem</a>
    /// </summary>
    public class BrowserHistory
    {
        private readonly List<string> _history;
        private int _currentIndex;

        public BrowserHistory(string homepage)
        {
            _history = [homepage];
            _currentIndex = 0;
        }

        public void Visit(string url)
        {
            _history.RemoveRange(_currentIndex + 1, _history.Count - _currentIndex - 1);
            _history.Add(url);
            _currentIndex++;
        }

        public string Back(int steps)
        {
            _currentIndex = Math.Max(0, _currentIndex - steps);
            return _history[_currentIndex];
        }

        public string Forward(int steps)
        {
            _currentIndex = Math.Min(_history.Count - 1, _currentIndex + steps);
            return _history[_currentIndex];
        }
    }
}
