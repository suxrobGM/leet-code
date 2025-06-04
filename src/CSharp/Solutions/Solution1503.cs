using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1503
{
    /// <summary>
    /// 1503. Last Moment Before All Ants Fall Out of a Plank - Medium
    /// <a href="https://leetcode.com/problems/last-moment-before-all-ants-fall-out-of-a-plank">See the problem</a>
    /// </summary>
    public int GetLastMoment(int n, int[] left, int[] right)
    {
        int maxLeft = left.Length > 0 ? left.Max() : 0;
        int maxRight = right.Length > 0 ? right.Max(i => n - i) : 0;
        return Math.Max(maxLeft, maxRight);
    }
}
