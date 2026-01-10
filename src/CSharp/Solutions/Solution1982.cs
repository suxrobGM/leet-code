namespace LeetCode.Solutions;

public class Solution1982
{
    /// <summary>
    /// 1982. Find Array Given Subset Sums - Hard
    /// <a href="https://leetcode.com/problems/find-array-given-subset-sums">See the problem</a>
    /// </summary>
    public int[] RecoverArray(int n, int[] sums)
    {
        if (n == 0) return [];

        Array.Sort(sums);

        // The difference between smallest two sums is a potential element
        int x = sums[1] - sums[0];

        // Use frequency map to partition sums
        var freq = new Dictionary<int, int>();
        foreach (var sum in sums)
        {
            freq[sum] = freq.GetValueOrDefault(sum, 0) + 1;
        }

        var without = new List<int>(); // Sums without element x
        var with = new List<int>();    // Sums with element x

        // Partition: for each sum s, pair it with s+x
        foreach (var sum in sums)
        {
            if (freq.GetValueOrDefault(sum, 0) > 0)
            {
                // This sum doesn't include x
                without.Add(sum);
                freq[sum]--;

                // The corresponding sum that includes x
                with.Add(sum + x);
                freq[sum + x]--;
            }
        }

        // Determine which group contains 0 (empty subset sum)
        // That group is the one WITHOUT the current element
        int[] remaining;
        int element;

        if (without.Contains(0))
        {
            // Group without x contains 0, so x is positive
            remaining = RecoverArray(n - 1, without.ToArray());
            element = x;
        }
        else
        {
            // Group with x contains 0, so x is negative
            // We recursed on the wrong group, use 'with' which is actually 'without -x'
            remaining = RecoverArray(n - 1, with.ToArray());
            element = -x;
        }

        // Build result
        int[] result = new int[n];
        Array.Copy(remaining, result, n - 1);
        result[n - 1] = element;

        return result;
    }
}
