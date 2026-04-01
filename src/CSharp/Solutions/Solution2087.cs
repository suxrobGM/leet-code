namespace LeetCode.Solutions;

public class Solution2087
{
    /// <summary>
    /// 2087. Minimum Cost Homecoming of a Robot in a Grid - Medium
    /// <a href="https://leetcode.com/problems/minimum-cost-homecoming-of-a-robot-in-a-grid">See the problem</a>
    /// </summary>
    public int MinCost(int[] startPos, int[] homePos, int[] rowCosts, int[] colCosts)
    {
        var cost = 0;
        var dr = startPos[0] < homePos[0] ? 1 : -1;
        var dc = startPos[1] < homePos[1] ? 1 : -1;

        for (var r = startPos[0] + dr; r != homePos[0] + dr; r += dr)
            cost += rowCosts[r];

        for (var c = startPos[1] + dc; c != homePos[1] + dc; c += dc)
            cost += colCosts[c];

        return cost;
    }
}
