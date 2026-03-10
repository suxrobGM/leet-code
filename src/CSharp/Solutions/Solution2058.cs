using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2058
{
    /// <summary>
    /// 2058. Find the Minimum and Maximum Number of Nodes Between Critical Points - Medium
    /// <a href="https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points">See the problem</a>
    /// </summary>
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        var criticalPoints = new List<int>();
        var index = 1;
        var prev = head;
        var current = head.next;

        while (current?.next is not null)
        {
            if ((current.val > prev.val && current.val > current.next.val) ||
                (current.val < prev.val && current.val < current.next.val))
                criticalPoints.Add(index);
            prev = current;
            current = current.next;
            index++;
        }

        if (criticalPoints.Count < 2)
            return [-1, -1];

        var minDistance = int.MaxValue;
        for (var i = 1; i < criticalPoints.Count; i++)
            minDistance = Math.Min(minDistance, criticalPoints[i] - criticalPoints[i - 1]);

        return [minDistance, criticalPoints.Last() - criticalPoints.First()];
    }
}
