namespace LeetCode.Solutions;

public class Solution2240
{
    /// <summary>
    /// 2240. Number of Ways to Buy Pens and Pencils - Medium
    /// <a href="https://leetcode.com/problems/number-of-ways-to-buy-pens-and-pencils">See the problem</a>
    /// </summary>
    public long WaysToBuyPensPencils(int total, int cost1, int cost2)
    {
        var ways = 0L;
        for (var i = 0; i * cost1 <= total; i++)
        {
            var remaining = total - i * cost1;
            ways += remaining / cost2 + 1;
        }

        return ways;
    }
}
