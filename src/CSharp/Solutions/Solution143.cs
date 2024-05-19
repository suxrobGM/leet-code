using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution143
{
    /// <summary>
    /// 143. Reorder List - Medium
    /// <a href="https://leetcode.com/problems/reorder-list">See the problem</a>
    /// </summary>
    public void ReorderList(ListNode head)
    {
        if (head?.next == null)
        {
            return;
        }

        // Step 1: Find the middle of the linked list
        ListNode slow = head, fast = head;
        while (fast is { next: not null })
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Step 2: Reverse the second half
        ListNode prev = null, curr = slow, temp;
        while (curr != null)
        {
            temp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = temp;
        }

        // Step 3: Merge the two halves
        ListNode first = head, second = prev;
        while (second?.next != null)
        {
            temp = first.next;
            first.next = second;
            first = temp;

            temp = second.next;
            second.next = first;
            second = temp;
        }
    }
}
