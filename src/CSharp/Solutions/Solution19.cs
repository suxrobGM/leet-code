using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution19
{
    /// <summary>
    /// 19. Remove Nth Node From End of List
    /// <a href="https://leetcode.com/problems/remove-nth-node-from-end-of-list/">See the problem</a>
    /// </summary>
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var dummy = new ListNode() { next = head };
        
        var slow = dummy;
        var fast = dummy;
        
        // Advance fast pointer by n steps
        for (var i = 0; i <= n; i++)
        {
            fast = fast.next;
        }
        
        // Move both pointers until fast reaches the end
        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next;
        }
        
        // Skip the nth node from the end
        slow.next = slow.next.next;
        return dummy.next;
    }
}
