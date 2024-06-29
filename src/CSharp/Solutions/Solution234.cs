using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution234
{
    /// <summary>
    /// 234. Palindrome Linked List - Easy
    /// <a href="https://leetcode.com/problems/palindrome-linked-list">See the problem</a>
    /// </summary>
    public bool IsPalindrome(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast?.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        slow = Reverse(slow);
        fast = head;

        while (slow != null)
        {
            if (slow.val != fast.val)
            {
                return false;
            }

            slow = slow.next;
            fast = fast.next;
        }

        return true;
    }

    private ListNode Reverse(ListNode head)
    {
        ListNode prev = null;

        while (head != null)
        {
            var next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }

        return prev;
    }
}
