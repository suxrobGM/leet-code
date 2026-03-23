using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2074
{
    /// <summary>
    /// 2074. Reverse Nodes in Even Length Groups - Medium
    /// <a href="https://leetcode.com/problems/reverse-nodes-in-even-length-groups">See the problem</a>
    /// </summary>
    public ListNode ReverseEvenLengthGroups(ListNode head)
    {
        var dummy = new ListNode(0, head);
        var prev = dummy;
        var current = head;
        var groupSize = 1;

        while (current != null)
        {
            var groupStart = current;
            var count = 0;

            // Count the number of nodes in the current group
            while (current != null && count < groupSize)
            {
                current = current.next;
                count++;
            }

            // If the group size is even, reverse the nodes in the group
            if (count % 2 == 0)
            {
                var reversedGroupHead = ReverseGroup(groupStart, count);
                prev.next = reversedGroupHead;
                prev = groupStart; // After reversal, groupStart becomes the tail of the group
            }
            else
            {
                prev.next = groupStart; // No reversal, just connect the previous part
                prev = GetTail(groupStart, count); // Move prev to the end of the current group
            }

            groupSize++;
        }

        return dummy.next;
    }

    private ListNode ReverseGroup(ListNode head, int count)
    {
        ListNode prev = null;
        var current = head;

        for (var i = 0; i < count; i++)
        {
            var next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev; // New head of the reversed group
    }

    private ListNode GetTail(ListNode head, int count)
    {
        var current = head;

        for (var i = 1; i < count; i++)
        {
            current = current.next;
        }

        return current; // Tail of the group
    }
}
