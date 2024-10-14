namespace LeetCode.Solutions;

public class Solution641
{
    /// <summary>
    /// 641. Design Circular Deque - Medium
    /// <a href="https://leetcode.com/problems/design-circular-deque">See the problem</a>
    /// </summary>
    public class MyCircularDeque
    {
        private int[] deque;
        private int front, rear, size, capacity;

        /** Initialize the deque with a maximum size of k */
        public MyCircularDeque(int k)
        {
            capacity = k;
            deque = new int[k];
            front = 0;
            rear = 0;
            size = 0;
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront(int value)
        {
            if (IsFull()) return false;
            front = (front - 1 + capacity) % capacity;  // Move front backwards in circular manner
            deque[front] = value;
            size++;
            return true;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if (IsFull()) return false;
            deque[rear] = value;
            rear = (rear + 1) % capacity;  // Move rear forwards in circular manner
            size++;
            return true;
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if (IsEmpty()) return false;
            front = (front + 1) % capacity;  // Move front forwards in circular manner
            size--;
            return true;
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if (IsEmpty()) return false;
            rear = (rear - 1 + capacity) % capacity;  // Move rear backwards in circular manner
            size--;
            return true;
        }

        /** Get the front item from the deque. Returns -1 if the deque is empty. */
        public int GetFront()
        {
            if (IsEmpty()) return -1;
            return deque[front];
        }

        /** Get the last item from the deque. Returns -1 if the deque is empty. */
        public int GetRear()
        {
            if (IsEmpty()) return -1;
            return deque[(rear - 1 + capacity) % capacity];  // Get the last element in a circular manner
        }

        /** Check if the deque is empty. */
        public bool IsEmpty()
        {
            return size == 0;
        }

        /** Check if the deque is full. */
        public bool IsFull()
        {
            return size == capacity;
        }
    }
}
