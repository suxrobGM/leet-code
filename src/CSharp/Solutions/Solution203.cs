using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution203
{
    /// <summary>
    /// 203. Remove Linked List Elements - Easy
    /// <a href="https://leetcode.com/problems/remove-linked-list-elements">See the problem</a>
    /// </summary>
    public ListNode RemoveElements(ListNode head, int val)
    {
        var dummy = new ListNode(0, head);
        var current = dummy;
        
        while (current.next != null)
        {
            if (current.next.val == val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
        
        return dummy.next;
    }
}
