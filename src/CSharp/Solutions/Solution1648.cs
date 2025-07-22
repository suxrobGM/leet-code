using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1648
{
    /// <summary>
    /// 1648. Sell Diminishing-Valued Colored Balls - Medium
    /// <a href="https://leetcode.com/problems/sell-diminishing-valued-colored-balls">See the problem</a>
    /// </summary>
    public int MaxProfit(int[] inventory, int orders)
    {
        const int MOD = 1_000_000_007;
        Array.Sort(inventory);
        Array.Reverse(inventory);

        long left = 0, right = inventory[0];

        // Binary search for the minimum price x such that we can fulfill the orders
        while (left < right)
        {
            long mid = (left + right) / 2;
            long count = 0;
            foreach (var inv in inventory)
            {
                if (inv > mid)
                    count += inv - mid;
                else
                    break;
            }

            if (count > orders)
                left = mid + 1;
            else
                right = mid;
        }

        long profit = 0;
        long remaining = orders;

        foreach (var inv in inventory)
        {
            if (inv >= left)
            {
                long num = inv - left;
                profit = (profit + SumFromTo(inv, left + 1)) % MOD;
                remaining -= num;
            }
            else
            {
                break;
            }
        }

        // Add remaining orders at price = left
        profit = (profit + (remaining * left) % MOD) % MOD;
        return (int)profit;
    }

    private long SumFromTo(long high, long low)
    {
        long count = high - low + 1;
        return ((high + low) * count) / 2;
    }
}
