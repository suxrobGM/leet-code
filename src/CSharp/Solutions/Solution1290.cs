using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1290
{
    /// <summary>
    /// 1290. Convert Binary Number in a Linked List to Integer - Easy
    /// <a href="https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer">See the problem</a>
    /// </summary>
    public int GetDecimalValue(ListNode head)
    {
        int result = 0;
        while (head != null)
        {
            result = (result << 1) | head.val; // Shift left and add the current bit
            head = head.next;
        }
        return result;
    }
}
