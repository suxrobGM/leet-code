namespace LeetCode.Solutions;

public class Solution225
{
    /// <summary>
    /// 225. Implement Stack using Queues - Easy
    /// <a href="https://leetcode.com/problems/implement-stack-using-queues">See the problem</a>
    /// </summary>
    public class MyStack
    {
        private Queue<int> _queue1 = new();
        private Queue<int> _queue2 = new();

        public void Push(int x)
        {
            _queue1.Enqueue(x);
        }

        public int Pop()
        {
            while (_queue1.Count > 1)
            {
                _queue2.Enqueue(_queue1.Dequeue());
            }

            var result = _queue1.Dequeue();

            (_queue2, _queue1) = (_queue1, _queue2);
            return result;
        }

        public int Top()
        {
            while (_queue1.Count > 1)
            {
                _queue2.Enqueue(_queue1.Dequeue());
            }

            var result = _queue1.Dequeue();
            _queue2.Enqueue(result);

            (_queue2, _queue1) = (_queue1, _queue2);
            return result;
        }

        public bool Empty()
        {
            return _queue1.Count == 0;
        }
    }
}
