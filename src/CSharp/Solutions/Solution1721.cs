using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1721
{
    /// <summary>
    /// 1721. Swapping Nodes in a Linked List - Medium
    /// <a href="https://leetcode.com/problems/swapping-nodes-in-a-linked-list">See the problem</a>
    /// </summary>
    public ListNode SwapNodes(ListNode head, int k)
    {
        // Move 'fast' to the k-th node
        var fast = head;
        for (int i = 1; i < k; i++) fast = fast.next;

        var kthFromStart = fast;

        // Now move 'fast' to the end, and 'slow' from head.
        // When fast reaches the last node, slow will be at the k-th from end.
        var slow = head;
        while (fast.next != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        var kthFromEnd = slow;

        // Swap values
        (kthFromEnd.val, kthFromStart.val) = (kthFromStart.val, kthFromEnd.val);
        return head;
    }
}
