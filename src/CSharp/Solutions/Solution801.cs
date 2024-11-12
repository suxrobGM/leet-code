
namespace LeetCode.Solutions;

public class Solution801
{
    /// <summary>
    /// 801. Minimum Swaps To Make Sequences Increasing - Hard
    /// <a href="https://leetcode.com/problems/minimum-swaps-to-make-sequences-increasing">See the problem</a>
    /// </summary>
    public int MinSwap(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;
        var swap = new int[n];
        var notSwap = new int[n];

        swap[0] = 1;

        for (var i = 1; i < n; i++)
        {
            swap[i] = n;
            notSwap[i] = n;

            if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1])
            {
                notSwap[i] = notSwap[i - 1];
                swap[i] = swap[i - 1] + 1;
            }

            if (nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1])
            {
                notSwap[i] = Math.Min(notSwap[i], swap[i - 1]);
                swap[i] = Math.Min(swap[i], notSwap[i - 1] + 1);
            }
        }

        return Math.Min(swap[n - 1], notSwap[n - 1]);
    }
}
