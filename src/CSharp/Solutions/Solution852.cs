using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution852
{
    /// <summary>
    /// 852. Peak Index in a Mountain Array - Medium
    /// <a href="https://leetcode.com/problems/peak-index-in-a-mountain-array">See the problem</a>
    /// </summary>
    public int PeakIndexInMountainArray(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] < arr[mid + 1])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}
