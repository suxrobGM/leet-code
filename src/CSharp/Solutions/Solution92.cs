using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution92
{
    /// <summary>
    /// 92. Reverse Linked List II - Medium
    /// <a href="https://leetcode.com/problems/reverse-linked-list-ii">See the problem</a>
    /// </summary>
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head is null)
        {
            return null;
        }

        var dummy = new ListNode(0)
        {
            next = head
        };
        var pre = dummy;

        for (var i = 0; i < left - 1; i++)
        {
            pre = pre.next;
        }

        var start = pre.next;
        var then = start.next;

        for (var i = 0; i < right - left; i++)
        {
            start.next = then.next;
            then.next = pre.next;
            pre.next = then;
            then = start.next;
        }

        return dummy.next;
    }
}
