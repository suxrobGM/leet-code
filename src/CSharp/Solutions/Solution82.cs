using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution82
{
    /// <summary>
    /// 82. Remove Duplicates from Sorted List II - Medium
    /// <a href="https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii">See the problem</a>
    /// </summary>
    public ListNode DeleteDuplicates(ListNode head)
    {
        var dummy = new ListNode(0, head);
        var prev = dummy;
        var current = head;

        while (current != null)
        {
            if (current.next != null && current.val == current.next.val)
            {
                while (current.next != null && current.val == current.next.val)
                {
                    current = current.next;
                }

                prev.next = current.next;
            }
            else
            {
                prev = prev.next;
            }

            current = current.next;
        }

        return dummy.next;
    }
}
