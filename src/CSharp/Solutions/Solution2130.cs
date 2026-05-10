using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2130
{
    /// <summary>
    /// 2130. Maximum Twin Sum of a Linked List - Medium
    /// <a href="https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list">See the problem</a>
    /// </summary>
    public int PairSum(ListNode head)
    {
        var values = new List<int>();
        var current = head;
        while (current != null)
        {
            values.Add(current.val);
            current = current.next;
        }

        var maxSum = 0;
        var n = values.Count;
        for (var i = 0; i < n / 2; i++)
        {
            var twinSum = values[i] + values[n - 1 - i];
            maxSum = Math.Max(maxSum, twinSum);
        }

        return maxSum;
    }
}
