using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution328
{
    /// <summary>
    /// 328. Odd Even Linked List - Medium
    /// <a href="https://leetcode.com/problems/odd-even-linked-list">See the problem</a>
    /// </summary>
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        var odd = head;
        var even = head.next;
        var evenHead = even;

        while (even != null && even.next != null)
        {
            odd.next = even.next;
            odd = odd.next;
            even.next = odd.next;
            even = even.next;
        }

        odd.next = evenHead;

        return head;
    }
}
