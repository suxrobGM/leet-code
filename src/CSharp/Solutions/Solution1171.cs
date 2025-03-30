using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1171
{
    /// <summary>
    /// 1171. Remove Zero Sum Consecutive Nodes from Linked List - Medium
    /// <a href="https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list">See the problem</a>
    /// </summary>
    public ListNode RemoveZeroSumSublists(ListNode head)
    {
        var dummy = new ListNode(0)
        {
            next = head
        };

        var prefixMap = new Dictionary<int, ListNode>();
        int prefixSum = 0;
        var curr = dummy;

        // First pass: Build prefix sum map
        while (curr != null)
        {
            prefixSum += curr.val;
            prefixMap[prefixSum] = curr; // store latest node with this sum
            curr = curr.next;
        }

        // Second pass: Re-link nodes, skipping zero-sum subsequences
        prefixSum = 0;
        curr = dummy;
        while (curr != null)
        {
            prefixSum += curr.val;
            curr.next = prefixMap[prefixSum].next;
            curr = curr.next;
        }

        return dummy.next;
    }
}
