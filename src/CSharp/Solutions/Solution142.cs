using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution142
{
    /// <summary>
    /// 142. Linked List Cycle II - Medium
    /// <a href="https://leetcode.com/problems/linked-list-cycle-ii">See the problem</a>
    /// </summary>
    public ListNode DetectCycle(ListNode head)
    {
        if (head?.next == null)
        {
            return null;
        }
        
        var slow = head;
        var fast = head;
        
        while (fast?.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            
            if (slow == fast)
            {
                var slow2 = head;
                
                while (slow2 != slow)
                {
                    slow = slow.next;
                    slow2 = slow2.next;
                }
                
                return slow;
            }
        }
        
        return null;
    }
}
