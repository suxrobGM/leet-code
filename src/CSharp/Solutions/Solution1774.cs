using System.Text;

namespace LeetCode.Solutions;

public class Solution1774
{
    private int best;
    private int target;

    /// <summary>
    /// 1774. Closest Dessert Cost - Medium
    /// <a href="https://leetcode.com/problems/closest-dessert-cost">See the problem</a>
    /// </summary>
    public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target)
    {
        this.target = target;
        best = baseCosts[0];

        foreach (int baseCost in baseCosts)
        {
            Dfs(toppingCosts, 0, baseCost);
        }

        return best;
    }

    private void Dfs(int[] toppings, int i, int current)
    {
        // Update best if closer, or tie but smaller
        if (Math.Abs(current - target) < Math.Abs(best - target) ||
            (Math.Abs(current - target) == Math.Abs(best - target) && current < best))
        {
            best = current;
        }

        // If already past target and worse than current best, stop
        if (i == toppings.Length) return;

        // Option 0: skip topping i
        Dfs(toppings, i + 1, current);

        // Option 1: take topping i once
        Dfs(toppings, i + 1, current + toppings[i]);

        // Option 2: take topping i twice
        Dfs(toppings, i + 1, current + 2 * toppings[i]);
    }
}
