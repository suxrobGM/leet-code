using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution206
{
    /// <summary>
    /// 206. Reverse Linked List - Easy
    /// <a href="https://leetcode.com/problems/reverse-linked-list">See the problem</a>
    /// </summary>
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        var current = head;

        while (current != null)
        {
            var next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }
}
