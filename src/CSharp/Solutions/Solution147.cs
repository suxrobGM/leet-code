using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution147
{
    /// <summary>
    /// 147. Insertion Sort List - Medium
    /// <a href="https://leetcode.com/problems/insertion-sort-list">See the problem</a>
    /// </summary>
    public ListNode InsertionSortList(ListNode head)
    {
        if (head?.next == null)
        {
            return head;
        }

        var dummy = new ListNode();
        var prev = dummy;
        var curr = head;

        while (curr != null)
        {
            var next = curr.next;

            if (prev.next != null && prev.next.val > curr.val)
            {
                prev = dummy;
            }

            while (prev.next != null && prev.next.val < curr.val)
            {
                prev = prev.next;
            }

            curr.next = prev.next;
            prev.next = curr;

            curr = next;
        }

        return dummy.next;
    }
}
