namespace LeetCode.Solutions;

public class Solution2333
{
    /// <summary>
    /// 2333. Minimum Sum of Squared Difference - Medium
    /// <a href="https://leetcode.com/problems/minimum-sum-of-squared-difference">See the problem</a>
    /// </summary>
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        int maxDifference = 0;
        long totalDifference = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            int difference = Math.Abs(nums1[i] - nums2[i]);
            maxDifference = Math.Max(maxDifference, difference);
            totalDifference += difference;
        }

        long operations = (long)k1 + k2;
        if (operations >= totalDifference)
        {
            return 0;
        }

        int[] frequencies = new int[maxDifference + 1];
        for (int i = 0; i < nums1.Length; i++)
        {
            frequencies[Math.Abs(nums1[i] - nums2[i])]++;
        }

        // Reducing a difference d saves 2d - 1, so reduce the largest differences first.
        for (int difference = maxDifference; difference > 0 && operations > 0; difference--)
        {
            int reductions = (int)Math.Min(operations, frequencies[difference]);
            frequencies[difference] -= reductions;
            frequencies[difference - 1] += reductions;
            operations -= reductions;
        }

        long result = 0;
        for (int difference = 1; difference <= maxDifference; difference++)
        {
            result += (long)difference * difference * frequencies[difference];
        }

        return result;
    }
}
