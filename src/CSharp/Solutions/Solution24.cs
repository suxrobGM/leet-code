using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution24
{
    /// <summary>
    /// 24. Swap Nodes in Pairs
    /// <a href="https://leetcode.com/problems/swap-nodes-in-pairs">See the problem</a>
    /// </summary>
    public ListNode SwapPairs(ListNode head)
    {
        var temp = head;
        
        while (temp is { next: not null })
        {
            (temp.val, temp.next.val) = (temp.next.val, temp.val);
            temp = temp.next.next;
        }
        
        return head;
    }
    
    public ListNode SwapPairs1(ListNode head) {
        if (head?.next is null) {
            return head;
        }

        var dummy = new ListNode(0, head);
        var prevNode = dummy;

        while (head is { next: not null }) 
        {
            // Nodes to be swapped
            var item1 = head;
            var item2 = head.next;

            // Swapping
            prevNode.next = item2;
            item1.next = item2.next;
            item2.next = item1;

            // Reinitializing the head and prevNode for next swap
            prevNode = item1;
            head = item1.next; // jump two nodes
        }

        return dummy.next;
    }
}
