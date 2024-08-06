using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution445
{
    /// <summary>
    /// 445. Add Two Numbers II - Medium
    /// <a href="https://leetcode.com/problems/add-two-numbers-ii">See the problem</a>
    /// </summary>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var stack1 = new Stack<int>();
        var stack2 = new Stack<int>();

        while (l1 != null)
        {
            stack1.Push(l1.val);
            l1 = l1.next;
        }

        while (l2 != null)
        {
            stack2.Push(l2.val);
            l2 = l2.next;
        }

        var carry = 0;
        ListNode head = null;

        while (stack1.Count > 0 || stack2.Count > 0 || carry > 0)
        {
            var sum = carry;

            if (stack1.Count > 0)
            {
                sum += stack1.Pop();
            }

            if (stack2.Count > 0)
            {
                sum += stack2.Pop();
            }

            carry = sum / 10;

            var node = new ListNode(sum % 10)
            {
                next = head
            };
            head = node;
        }

        return head;
    }
}
