using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution21
{
    /// <summary>
    /// You are given the heads of two sorted linked lists list1 and list2.
    /// Merge the two lists in a one sorted list.The list should be made by splicing together the nodes of the first two lists.
    /// Return the head of the merged linked list.
    /// <a href="https://leetcode.com/problems/merge-two-sorted-lists/">See the problem</a>
    /// </summary>
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var dummy = new ListNode();
        var head = dummy;

        while (list1 != null && list2 != null) 
        {
            if (list1.val < list2.val) 
            {
                head.next = list1;
                list1 = list1.next;
            }
            else 
            {
                head.next = list2;
                list2 = list2.next;
            }
            head = head.next;
        }

        head.next = list1 ?? list2;
        return dummy.next;
    }
}
