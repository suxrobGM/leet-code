using System.Text;

namespace LeetCode.Solutions;

public class Solution1775
{
    private int best;
    private int target;

    /// <summary>
    /// 1775. Equal Sum Arrays With Minimum Number of Operations - Medium
    /// <a href="https://leetcode.com/problems/equal-sum-arrays-with-minimum-number-of-operations">See the problem</a>
    /// </summary>
    public int MinOperations(int[] nums1, int[] nums2)
    {
        int sum1 = nums1.Sum();
        int sum2 = nums2.Sum();

        // Ensure sum1 >= sum2
        if (sum1 < sum2)
        {
            (nums2, nums1) = (nums1, nums2);
            (sum2, sum1) = (sum1, sum2);
        }

        int diff = sum1 - sum2;
        if (diff == 0) return 0;

        // Gather possible changes
        var changes = new List<int>();
        foreach (var v in nums1)
        {
            if (v > 1) changes.Add(v - 1);   // possible decrease
        }
        foreach (var v in nums2)
        {
            if (v < 6) changes.Add(6 - v);   // possible increase
        }

        if (changes.Count == 0) return -1;

        // Sort descending
        changes.Sort((a, b) => b.CompareTo(a));

        int ops = 0;
        foreach (int gain in changes)
        {
            diff -= gain;
            ops++;
            if (diff <= 0) return ops;
        }

        return -1; // Not enough even with all changes
    }
}
