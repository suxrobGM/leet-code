using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution382
{
    /// <summary>
    /// 382. Linked List Random Node - Medium
    /// <a href="https://leetcode.com/problems/linked-list-random-node">See the problem</a>
    /// </summary>
    public class Solution
    {
        private readonly ListNode _head;
        private readonly Random _random;

        public Solution(ListNode head)
        {
            _head = head;
            _random = new Random();
        }

        public int GetRandom()
        {
            var result = 0;
            var count = 0;
            var current = _head;

            while (current != null)
            {
                count++;
                if (_random.Next(1, count + 1) == count)
                {
                    result = current.val;
                }

                current = current.next;
            }

            return result;
        }
    }
}
