using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2095
{
    /// <summary>
    /// 2095. Delete the Middle Node of a Linked List - Medium
    /// <a href="https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list">See the problem</a>
    /// </summary>
    public ListNode DeleteMiddle(ListNode head)
    {
        if (head.next == null) return null;

        var slow = head;
        var fast = head;
        ListNode prev = null;

        while (fast != null && fast.next != null)
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        prev.next = slow.next;

        return head;
    }
}
