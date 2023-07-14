package Java.Solutions;

import Java.ListNode;

class Solution83 {
    /**
     * Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.
     * @see https://leetcode.com/problems/remove-duplicates-from-sorted-list
     */
    public ListNode deleteDuplicates(ListNode head) {
        var node = head;
        
        while (node != null) {
            var nextNode = node.next;

            if (nextNode == null)
                break;

            if (node.val == nextNode.val) {
                node.next = nextNode.next; 
            }
            else {
                node = nextNode;
            }
        }

        return head;
    }
}
