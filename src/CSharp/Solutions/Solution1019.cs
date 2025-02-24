using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1019
{
    /// <summary>
    /// 1019. Next Greater Node In Linked List - Medium
    /// <a href="https://leetcode.com/problems/next-greater-node-in-linked-list</a>
    /// </summary>
    public int[] NextLargerNodes(ListNode head)
    {
        var result = new List<int>();
        var stack = new Stack<(int, int)>();
        var index = 0;
        while (head != null)
        {
            result.Add(0);
            while (stack.Count > 0 && stack.Peek().Item1 < head.val)
            {
                var (value, i) = stack.Pop();
                result[i] = head.val;
            }
            stack.Push((head.val, index++));
            head = head.next;
        }

        return result.ToArray();
    }
}
