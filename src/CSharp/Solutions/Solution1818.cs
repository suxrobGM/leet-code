using System.Text;

namespace LeetCode.Solutions;

public class Solution1818
{
    /// <summary>
    /// 1818. Minimum Absolute Sum Difference - Medium
    /// <a href="https://leetcode.com/problems/minimum-absolute-sum-difference">See the problem</a>
    /// </summary>
    public int MinAbsoluteSumDiff(int[] nums1, int[] nums2)
    {
        const long MOD = 1_000_000_007;
        int n = nums1.Length;
        long sum = 0, bestGain = 0;

        int[] sorted = nums1.ToArray();
        Array.Sort(sorted);

        for (int i = 0; i < n; i++)
        {
            long diff = Math.Abs(nums1[i] - nums2[i]);
            sum += diff;

            // find closest value to nums2[i] in sorted
            int idx = Array.BinarySearch(sorted, nums2[i]);
            if (idx < 0) idx = ~idx;

            long best = diff;
            if (idx < n) best = Math.Min(best, Math.Abs((long)sorted[idx] - nums2[i]));
            if (idx > 0) best = Math.Min(best, Math.Abs((long)sorted[idx - 1] - nums2[i]));

            bestGain = Math.Max(bestGain, diff - best);
        }

        return (int)((sum - bestGain) % MOD);
    }
}
