using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1114
{
    /// <summary>
    /// 1114. Print in Order - Easy
    /// <a href="https://leetcode.com/problems/print-in-order">See the problem</a>
    /// </summary>
    public class Foo
    {
        private readonly object _lock = new();
        private bool _firstPrinted;
        private bool _secondPrinted;

        public Foo()
        {
            _firstPrinted = false;
            _secondPrinted = false;
        }

        public void First(Action printFirst)
        {
            lock (_lock)
            {
                printFirst();
                _firstPrinted = true;
                Monitor.PulseAll(_lock);
            }
        }

        public void Second(Action printSecond)
        {
            lock (_lock)
            {
                while (!_firstPrinted)
                {
                    Monitor.Wait(_lock);
                }
                printSecond();
                _secondPrinted = true;
                Monitor.PulseAll(_lock);
            }
        }

        public void Third(Action printThird)
        {
            lock (_lock)
            {
                while (!_secondPrinted)
                {
                    Monitor.Wait(_lock);
                }
                printThird();
            }
        }
    }
}
