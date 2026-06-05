namespace LeetCode.Solutions;

public class Solution2162
{
    /// <summary>
    /// 2162. Minimum Cost to Set Cooking Time - Medium
    /// <a href="https://leetcode.com/problems/minimum-cost-to-set-cooking-time">See the problem</a>
    /// </summary>
    public int MinCostSetTime(int startAt, int moveCost, int pushCost, int targetSeconds)
    {
        int Cost(int m, int s)
        {
            int code = m * 100 + s;
            int cost = 0, current = startAt;
            foreach (char c in code.ToString())
            {
                int d = c - '0';
                if (d != current) cost += moveCost;
                cost += pushCost;
                current = d;
            }
            return cost;
        }

        int m = targetSeconds / 60, s = targetSeconds % 60;
        int best = int.MaxValue;
        if (m <= 99) best = Math.Min(best, Cost(m, s));
        if (m >= 1 && s + 60 <= 99) best = Math.Min(best, Cost(m - 1, s + 60));
        return best;
    }
}
