using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1953
{
    /// <summary>
    /// 1953. Maximum Number of Weeks for Which You Can Work - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-weeks-for-which-you-can-work">See the problem</a>
    /// </summary>
    public long NumberOfWeeks(int[] milestones)
    {
        long totalMilestones = 0;
        int maxMilestones = 0;

        foreach (var milestone in milestones)
        {
            totalMilestones += milestone;
            if (milestone > maxMilestones)
            {
                maxMilestones = milestone;
            }
        }

        long remainingMilestones = totalMilestones - maxMilestones;

        if (maxMilestones > remainingMilestones + 1)
        {
            return remainingMilestones * 2 + 1;
        }
        else
        {
            return totalMilestones;
        }
    }
}
