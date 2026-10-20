namespace LeetCode.Solutions;

public class Solution2321
{
    /// <summary>
    /// 2321. Maximum Score Of Spliced Array - Hard
    /// <a href="https://leetcode.com/problems/maximum-score-of-spliced-array">See the problem</a>
    /// </summary>
    public int MaximumsSplicedArray(int[] nums1, int[] nums2)
    {
        var sum1 = 0;
        var sum2 = 0;
        var gain1 = 0;
        var gain2 = 0;
        var bestGain1 = 0;
        var bestGain2 = 0;

        for (var i = 0; i < nums1.Length; i++)
        {
            sum1 += nums1[i];
            sum2 += nums2[i];

            // A swap adds the segment's differences to one array's sum.
            var difference = nums2[i] - nums1[i];

            // Kadane's algorithm finds the best segment for each array.
            // A zero gain allows us to skip the swap entirely.
            gain1 = Math.Max(0, gain1 + difference);
            gain2 = Math.Max(0, gain2 - difference);
            bestGain1 = Math.Max(bestGain1, gain1);
            bestGain2 = Math.Max(bestGain2, gain2);
        }

        return Math.Max(sum1 + bestGain1, sum2 + bestGain2);
    }
}
