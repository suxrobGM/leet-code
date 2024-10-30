using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution725
{
    /// <summary>
    /// 725. Split Linked List in Parts - Medium
    /// <a href="https://leetcode.com/problems/split-linked-list-in-parts">See the problem</a>
    /// </summary>
    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        var n = 0;
        var current = head;

        while (current != null)
        {
            n++;
            current = current.next;
        }

        var width = n / k;
        var remainder = n % k;
        var parts = new ListNode[k];
        current = head;

        for (var i = 0; i < k; i++)
        {
            var part = new ListNode(0);
            var write = part;

            for (var j = 0; j < width + (i < remainder ? 1 : 0); j++)
            {
                write.next = new ListNode(current?.val ?? 0);
                write = write.next;

                if (current != null)
                {
                    current = current.next;
                }
            }

            parts[i] = part.next;
        }

        return parts;
    }
}
