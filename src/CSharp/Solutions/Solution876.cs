using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution876
{
    /// <summary>
    /// 876. Middle of the Linked List - Easy
    /// <a href="https://leetcode.com/problems/middle-of-the-linked-list">See the problem</a>
    /// </summary>
    public ListNode MiddleNode(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }
}
