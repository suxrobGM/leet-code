using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution148
{
    /// <summary>
    /// 148. Sort List - Medium
    /// <a href="https://leetcode.com/problems/sort-list">See the problem</a>
    /// </summary>
    public ListNode SortList(ListNode head)
    {
        if (head?.next == null)
        {
            return head;
        }

        var slow = head;
        var fast = head;
        ListNode prev = null;

        while (fast is { next: not null })
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        prev!.next = null;

        return Merge(SortList(head), SortList(slow));
    }
    
    private ListNode Merge(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode();
        var curr = dummy;

        while (l1 != null && l2 != null)
        {
            if (l1.val < l2.val)
            {
                curr.next = l1;
                l1 = l1.next;
            }
            else
            {
                curr.next = l2;
                l2 = l2.next;
            }

            curr = curr.next;
        }

        curr.next = l1 ?? l2;

        return dummy.next;
    }
}
