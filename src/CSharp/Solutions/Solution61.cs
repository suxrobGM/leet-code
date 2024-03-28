using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution61
{
    /// <summary>
    /// 61. Rotate List - Medium
    /// <a href="https://leetcode.com/problems/rotate-list">See the problem</a>
    /// </summary>
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head?.next is null || k == 0)
        {
            return head;
        }

        var length = 1;
        var current = head;

        // Calculate the length of the list
        while (current.next != null)
        {
            length++;
            current = current.next;
        }

        k %= length; // Calculate the effective number of rotations

        if (k == 0)
        {
            return head;
        }

        // Create a cycle in the list
        current.next = head;
        current = head;

        // Move the current pointer to the node before the new head
        for (var i = 0; i < length - k - 1; i++)
        {
            current = current.next;
        }

        // Update the new head and break the cycle
        var newHead = current.next;
        current.next = null;

        return newHead;
    }
}
