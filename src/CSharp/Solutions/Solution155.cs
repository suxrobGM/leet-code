namespace LeetCode.Solutions;

public class Solution155
{
    /// <summary>
    /// 155. Min Stack - Medium
    /// <a href="https://leetcode.com/problems/min-stack">See the problem</a>
    /// </summary>
    public class MinStack
    {
        private readonly Stack<int> _stack = new();
        private readonly Stack<int> _minStack = new();

        public void Push(int val)
        {
            _stack.Push(val);

            if (_minStack.Count == 0 || val <= _minStack.Peek())
            {
                _minStack.Push(val);
            }
        }

        public void Pop()
        {
            if (_stack.Count == 0)
            {
                return;
            }

            if (_stack.Peek() == _minStack.Peek())
            {
                _minStack.Pop();
            }

            _stack.Pop();
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _minStack.Peek();
        }
    }
}
