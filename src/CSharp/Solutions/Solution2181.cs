using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2181
{
    /// <summary>
    /// 2181. Merge Nodes in Between Zeros - Medium
    /// <a href="https://leetcode.com/problems/merge-nodes-in-between-zeros">See the problem</a>
    /// </summary>
    public ListNode MergeNodes(ListNode head)
    {
        // Reuse the existing nodes: 'writer' holds the sum between two zeros.
        var writer = head;
        var sum = 0;
        var current = head.next;

        while (current != null)
        {
            if (current.val == 0)
            {
                // A separating zero ends the current group; store the sum.
                writer.val = sum;
                sum = 0;

                if (current.next != null)
                {
                    writer = writer.next;
                }
            }
            else
            {
                sum += current.val;
            }

            current = current.next;
        }

        writer.next = null;
        return head;
    }
}
