namespace LeetCode.Solutions;

public partial class Solution
{
    /// <summary>
    /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
    /// The overall run time complexity should be O(log (m+n))
    /// <see href="https://leetcode.com/problems/median-of-two-sorted-arrays/">See the problem</see>
    /// </summary>
    /// <remarks>Time complexity O(n*log(n))</remarks>
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var len1 = nums1.Length;
        var len2 = nums2.Length;
        var mergedLen = len1 + len2;
        var mergedArr = new int[mergedLen];
        
        if (mergedLen == 1)
        {
            return len1 != 0 ? nums1[0] : len2 != 0 ? nums2[0] : 0;
        }

        Array.Copy(nums1, mergedArr, len1);
        Array.Copy(nums2, 0, mergedArr, len1, len2);
        Array.Sort(mergedArr);

        double median;
        var midIndex = mergedLen / 2;

        if (mergedLen % 2 == 0)
        {
            median = (mergedArr[midIndex] + mergedArr[midIndex - 1]) / 2.0;
        }
        else
        {
            median = mergedArr[midIndex];
        }

        return median;
    }
}
