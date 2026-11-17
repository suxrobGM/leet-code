namespace LeetCode.Solutions;

public class Solution2358
{
    /// <summary>
    /// 2358. Maximum Number of Groups Entering a Competition - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-groups-entering-a-competition">See the problem</a>
    /// </summary>
    public int MaximumGroups(int[] grades)
    {
        int remainingStudents = grades.Length;
        int groups = 0;

        // In sorted order, larger groups of positive grades also have larger sums.
        // Count the minimum sizes 1, 2, 3, ... and put any leftovers in the last group.
        while (remainingStudents >= groups + 1)
        {
            groups++;
            remainingStudents -= groups;
        }

        return groups;
    }
}
