using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1669
{
    /// <summary>
    /// 1669. Merge In Between Linked Lists - Medium
    /// <a href="https://leetcode.com/problems/merge-in-between-linked-lists">See the problem</a>
    /// </summary>
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        var dummy = new ListNode(-1, list1);
        var prevA = dummy;

        // Step 1: Find node at position a - 1
        for (int i = 0; i < a; i++)
            prevA = prevA.next;

        // Step 2: Find node at position b + 1
        var afterB = prevA;
        for (int i = 0; i <= b - a + 1; i++)
            afterB = afterB.next;

        // Step 3: Connect prevA to list2 head
        prevA.next = list2;

        // Step 4: Go to the end of list2
        var tail = list2;
        while (tail.next != null)
            tail = tail.next;

        // Step 5: Connect tail of list2 to afterB
        tail.next = afterB;

        return list1;
    }
}
