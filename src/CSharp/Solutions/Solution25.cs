using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution25
{
    /// <summary>
    /// 25. Reverse Nodes in k-Group
    /// <a href="https://leetcode.com/problems/reverse-nodes-in-k-group">See the problem</a>
    /// </summary>
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (head == null || k == 1) {
            return head;
        }

        // Dummy node
        var dummy = new ListNode(0) {
            next = head
        };

        // Count the number of nodes in the list
        var current = head;
        var count = 0;
        while (current != null) {
            count++;
            current = current.next;
        }

        // Reverse in groups
        var prevTail = dummy;
        var nextHead = dummy.next;
        
        while (count >= k) {
            current = nextHead;
            ListNode prev = null;

            // Reverse k nodes
            for (var i = 0; i < k; i++) {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            // Connect the reversed group with the rest of the list
            // prevTail.next points to the start of the reversed group
            // prevTail is updated to the start of the group before reversal
            var temp = prevTail.next;
            prevTail.next = prev;
            prevTail = temp;
            prevTail.next = current;
        
            // Update nextHead for the next group
            nextHead = current;
            count -= k;
        }

        return dummy.next;
    }
}
