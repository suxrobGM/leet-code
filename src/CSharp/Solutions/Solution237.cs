using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution237
{
    /// <summary>
    /// 237. Delete Node in a Linked List - Medium
    /// <a href="https://leetcode.com/problems/delete-node-in-a-linked-list">See the problem</a>
    /// </summary>
    public void DeleteNode(ListNode node)
    {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}
