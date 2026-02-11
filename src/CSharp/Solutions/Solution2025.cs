namespace LeetCode.Solutions;

public class Solution2025
{
    /// <summary>
    /// 2025. Maximum Number of Ways to Partition an Array - Hard
    /// <a href="https://leetcode.com/problems/maximum-number-of-ways-to-partition-an-array">See the problem</a>
    /// </summary>
    public int WaysToPartition(int[] nums, int k)
    {
        var n = nums.Length;
        var prefix = new long[n];
        prefix[0] = nums[0];
        for (var i = 1; i < n; i++)
            prefix[i] = prefix[i - 1] + nums[i];

        var totalSum = prefix[n - 1];

        // Count valid pivots with no replacement: prefix[i] == totalSum - prefix[i]
        // i.e. 2*prefix[i] == totalSum, for i in [0, n-2]

        // left: counts of prefix[j] for j < i (pivots before index i)
        // right: counts of prefix[j] for j >= i but j < n-1 (pivots at/after index i)
        var left = new Dictionary<long, int>();
        var right = new Dictionary<long, int>();

        // Initially all pivot diffs go into right (pivots at indices 0..n-2)
        for (var j = 0; j < n - 1; j++)
        {
            var diff = 2 * prefix[j] - totalSum; // prefix[j] - (totalSum - prefix[j])
            right.TryGetValue(diff, out var c);
            right[diff] = c + 1;
        }

        // No replacement: count pivots where diff == 0
        right.TryGetValue(0L, out int best);

        // Try replacing nums[i] with k
        for (var i = 0; i < n; i++)
        {
            var d = (long)k - nums[i];
            // Replacing nums[i]: pivots j < i need diff == d, pivots j >= i need diff == -d
            var count = 0;
            if (left.TryGetValue(d, out var lc)) count += lc;
            if (right.TryGetValue(-d, out var rc)) count += rc;
            best = Math.Max(best, count);

            // Move pivot i from right to left (only if i < n-1, i.e. it's a valid pivot)
            if (i < n - 1)
            {
                var diff = 2 * prefix[i] - totalSum;
                right[diff]--;
                left.TryGetValue(diff, out var olc);
                left[diff] = olc + 1;
            }
        }

        return best;
    }
}
