using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution817
{
    /// <summary>
    /// 817. Linked List Components - Medium
    /// <a href="https://leetcode.com/problems/linked-list-components">See the problem</a>
    /// </summary>
    public int NumComponents(ListNode head, int[] nums)
    {
        var numSet = new HashSet<int>(nums);
        var current = head;
        var result = 0;

        while (current != null)
        {
            if (numSet.Contains(current.val) && (current.next == null || !numSet.Contains(current.next.val)))
            {
                result++;
            }

            current = current.next;
        }

        return result;
    }
}
