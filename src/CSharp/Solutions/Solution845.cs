using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution845
{
    /// <summary>
    /// 845. Longest Mountain in Array - Medium
    /// <a href="https://leetcode.com/problems/longest-mountain-in-array">See the problem</a>
    /// </summary>
    public int LongestMountain(int[] arr)
    {
        int n = arr.Length;
        int longestMountain = 0;

        for (int i = 1; i < n - 1; i++)
        {
            if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1])
            {
                int left = i - 1;
                int right = i + 1;

                while (left > 0 && arr[left - 1] < arr[left])
                {
                    left--;
                }

                while (right < n - 1 && arr[right] > arr[right + 1])
                {
                    right++;
                }

                longestMountain = Math.Max(longestMountain, right - left + 1);
            }
        }

        return longestMountain;
    }
}
