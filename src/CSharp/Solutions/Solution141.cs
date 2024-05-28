using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution141
{
    /// <summary>
    /// 141. Linked List Cycle - Easy
    /// <a href="https://leetcode.com/problems/linked-list-cycle">See the problem</a>
    /// </summary>
    public bool HasCycle(ListNode head)
    {
        if (head?.next == null)
        {
            return false;
        }
        
        var slow = head;
        var fast = head.next;
        
        while (slow != fast)
        {
            if (fast?.next == null)
            {
                return false;
            }
            
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return true;
    }
}
