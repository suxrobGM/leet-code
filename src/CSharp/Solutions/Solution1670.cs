using System.Text;


namespace LeetCode.Solutions;

public class Solution1670
{
    /// <summary>
    /// 1670. Design Front Middle Back Queue - Medium
    /// <a href="https://leetcode.com/problems/design-front-middle-back-queue">See the problem</a>
    /// </summary>
    public class FrontMiddleBackQueue
    {
        private readonly LinkedList<int> left = [];
        private readonly LinkedList<int> right = [];

        public void PushFront(int val)
        {
            left.AddFirst(val);
            Balance();
        }

        public void PushMiddle(int val)
        {
            if (left.Count > right.Count)
            {
                right.AddFirst(left.Last.Value);
                left.RemoveLast();
            }
            left.AddLast(val);
        }

        public void PushBack(int val)
        {
            right.AddLast(val);
            Balance();
        }

        public int PopFront()
        {
            if (IsEmpty()) return -1;

            int val;
            if (left.Count > 0)
            {
                val = left.First.Value;
                left.RemoveFirst();
            }
            else
            {
                val = right.First.Value;
                right.RemoveFirst();
            }

            Balance();
            return val;
        }

        public int PopMiddle()
        {
            if (IsEmpty()) return -1;

            int val = left.Last.Value;
            left.RemoveLast();
            Balance();
            return val;
        }

        public int PopBack()
        {
            if (IsEmpty()) return -1;

            int val;
            if (right.Count > 0)
            {
                val = right.Last.Value;
                right.RemoveLast();
            }
            else
            {
                val = left.Last.Value;
                left.RemoveLast();
            }

            Balance();
            return val;
        }

        private void Balance()
        {
            // Maintain invariant: left.Count == right.Count OR left.Count == right.Count + 1
            while (left.Count > right.Count + 1)
            {
                right.AddFirst(left.Last.Value);
                left.RemoveLast();
            }

            while (left.Count < right.Count)
            {
                left.AddLast(right.First.Value);
                right.RemoveFirst();
            }
        }

        private bool IsEmpty()
        {
            return left.Count == 0 && right.Count == 0;
        }
    }
}
