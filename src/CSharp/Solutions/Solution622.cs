using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution622
{
    /// <summary>
    /// 622. Design Circular Queue - Medium
    /// <a href="https://leetcode.com/problems/design-circular-queue">See the problem</a>
    /// </summary>
    public class MyCircularQueue
    {
        private readonly int[] _queue;
        private int _head;
        private int _tail;
        private int _size;
        
        public MyCircularQueue(int k)
        {
            _queue = new int[k];
            _head = 0;
            _tail = -1;
            _size = 0;
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
            {
                return false;
            }
            _tail = (_tail + 1) % _queue.Length;
            _queue[_tail] = value;
            _size++;
            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
            {
                return false;
            }
            _head = (_head + 1) % _queue.Length;
            _size--;
            return true;
        }

        public int Front()
        {
            return IsEmpty() ? -1 : _queue[_head];
        }

        public int Rear()
        {
            return IsEmpty() ? -1 : _queue[_tail];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public bool IsFull()
        {
            return _size == _queue.Length;
        }
    }
}
