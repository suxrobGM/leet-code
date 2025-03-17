using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1115
{
    /// <summary>
    /// 1115. Print FooBar Alternately - Medium
    /// <a href="https://leetcode.com/problems/print-foobar-alternately">See the problem</a>
    /// </summary>
    public class FooBar
    {
        private readonly int _n;
        private readonly object _lock = new();
        private bool _fooPrinted;

        public FooBar(int n)
        {
            _n = n;
            _fooPrinted = false;
        }

        public void Foo(Action printFoo)
        {
            for (var i = 0; i < _n; i++)
            {
                lock (_lock)
                {
                    while (_fooPrinted)
                    {
                        Monitor.Wait(_lock);
                    }
                    printFoo();
                    _fooPrinted = true;
                    Monitor.PulseAll(_lock);
                }
            }
        }

        public void Bar(Action printBar)
        {
            for (var i = 0; i < _n; i++)
            {
                lock (_lock)
                {
                    while (!_fooPrinted)
                    {
                        Monitor.Wait(_lock);
                    }
                    printBar();
                    _fooPrinted = false;
                    Monitor.PulseAll(_lock);
                }
            }
        }
    }
}
