namespace LeetCode.Solutions;

public partial class Solution
{
    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers.
    /// The digits are stored in reverse order, and each of their nodes contains a single digit.
    /// Add the two numbers and return the sum as a linked list.
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// <see href="https://leetcode.com/problems/add-two-numbers/">See the problem</see>
    /// </summary>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        if (l1 == null || l2 == null)
            return l1 ?? l2;

        var temp = new ListNode(0);
        var prev = temp;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            carry += l1 == null ? 0 : l1.val;
            carry += l2 == null ? 0 : l2.val;
            l1 = l1?.next;
            l2 = l2?.next;

            prev.next = new ListNode(carry % 10);
            prev = prev.next;
            carry /= 10;
        }

        return temp.next;
    }
}
