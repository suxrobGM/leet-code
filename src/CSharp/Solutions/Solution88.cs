namespace LeetCode.Solutions;

public class Solution88
{
    /// <summary>
    /// 88. Merge Sorted Array
    /// <a href="https://leetcode.com/problems/merge-sorted-array">See the problem</a>
    /// </summary>
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        for (var i = 0; i < n; i++)
        {
            var index = m + i;
            nums1[index] = nums2[i];
        }
        
        Array.Sort(nums1);
    }
}
