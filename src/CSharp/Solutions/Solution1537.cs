using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1537
{
    /// <summary>
    /// 1537. Get the Maximum Score - Hard
    /// <a href="https://leetcode.com/problems/get-the-maximum-score">See the problem</a>
    /// </summary>
    public int MaxSum(int[] nums1, int[] nums2)
    {
        const int mod = 1_000_000_007;
        int i = 0, j = 0;
        long sum1 = 0, sum2 = 0, result = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                sum1 += nums1[i++];
            }
            else if (nums1[i] > nums2[j])
            {
                sum2 += nums2[j++];
            }
            else
            {
                result += Math.Max(sum1, sum2) + nums1[i];
                result %= mod;
                sum1 = 0;
                sum2 = 0;
                i++;
                j++;
            }
        }

        while (i < nums1.Length)
        {
            sum1 += nums1[i++];
        }

        while (j < nums2.Length)
        {
            sum2 += nums2[j++];
        }

        result += Math.Max(sum1, sum2);
        return (int)(result % mod);
    }
}
