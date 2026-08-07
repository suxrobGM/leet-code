namespace LeetCode.Solutions;

public class Solution2234
{
    /// <summary>
    /// 2234. Maximum Total Beauty of the Gardens - Hard
    /// <a href="https://leetcode.com/problems/maximum-total-beauty-of-the-gardens">See the problem</a>
    /// </summary>
    public long MaximumBeauty(int[] flowers, long newFlowers, int target, int full, int partial)
    {
        // Anything above the target is wasted, so clamp first and sort ascending: the
        // cheapest gardens to complete are the last ones, and the minimum of the
        // incomplete ones is driven by the first ones.
        var n = flowers.Length;
        var sorted = new int[n];
        for (var i = 0; i < n; i++)
        {
            sorted[i] = Math.Min(flowers[i], target);
        }

        Array.Sort(sorted);

        // prefix[i] = sum of the first i gardens, used to price "raise everything to x".
        var prefix = new long[n + 1];
        for (var i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + sorted[i];
        }

        var best = 0L;
        long completionCost = 0;

        // i = number of gardens left incomplete, so gardens [i, n) are the completed suffix.
        for (var i = n; i >= 0; i--)
        {
            if (i < n)
            {
                completionCost += target - sorted[i];
            }

            if (completionCost > newFlowers)
            {
                break;
            }

            var beauty = (long)(n - i) * full;
            if (i > 0)
            {
                if (sorted[i - 1] == target)
                {
                    // Fewer than i gardens start below the target, so this split cannot happen.
                    continue;
                }

                beauty += (long)MaxMinimum(sorted, prefix, i, newFlowers - completionCost, target - 1) * partial;
            }

            best = Math.Max(best, beauty);
        }

        return best;
    }

    /// <summary>
    /// Largest value every one of the first <paramref name="count"/> gardens can reach with
    /// <paramref name="budget"/> flowers, never exceeding <paramref name="cap"/>.
    /// </summary>
    private static int MaxMinimum(int[] sorted, long[] prefix, int count, long budget, int cap)
    {
        var low = 0;
        var high = cap;
        while (low < high)
        {
            var mid = low + (high - low + 1) / 2;

            // Gardens below mid form a prefix, so raising them costs mid * below - their sum.
            var below = LowerBound(sorted, count, mid);
            if (mid * (long)below - prefix[below] <= budget)
            {
                low = mid;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;
    }

    private static int LowerBound(int[] sorted, int count, int value)
    {
        var low = 0;
        var high = count;
        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (sorted[mid] < value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }
}
