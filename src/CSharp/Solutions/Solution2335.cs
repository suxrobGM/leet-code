namespace LeetCode.Solutions;

public class Solution2335
{
    /// <summary>
    /// 2335. Minimum Amount of Time to Fill Cups - Easy
    /// <a href="https://leetcode.com/problems/minimum-amount-of-time-to-fill-cups">See the problem</a>
    /// </summary>
    public int FillCups(int[] amount)
    {
        int total = amount[0] + amount[1] + amount[2];
        int maximum = Math.Max(amount[0], Math.Max(amount[1], amount[2]));

        // Each type needs its own seconds, and at most two cups can be filled per second.
        return Math.Max(maximum, (total + 1) / 2);
    }
}
