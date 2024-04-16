using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution86
{
    /// <summary>
    /// 86. Partition List - Medium
    /// <a href="https://leetcode.com/problems/partition-list">See the problem</a>
    /// </summary>
    public ListNode Partition(ListNode head, int x)
    {
        var dummy1 = new ListNode(0);
        var dummy2 = new ListNode(0);
        var current1 = dummy1;
        var current2 = dummy2;

        while (head != null)
        {
            if (head.val < x)
            {
                current1.next = head;
                current1 = current1.next;
            }
            else
            {
                current2.next = head;
                current2 = current2.next;
            }

            head = head.next;
        }

        current2.next = null;
        current1.next = dummy2.next;

        return dummy1.next;
    }
}
