using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1855
{
    /// <summary>
    /// 1855. Maximum Distance Between a Pair of Values - Medium
    /// <a href="https://leetcode.com/problems/maximum-distance-between-a-pair-of-values">See the problem</a>
    /// </summary>
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        int maxDistance = 0;
        int j = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            while (j < nums2.Length && nums1[i] <= nums2[j])
            {
                maxDistance = Math.Max(maxDistance, j - i);
                j++;
            }
        }
        return maxDistance;
    }
}
