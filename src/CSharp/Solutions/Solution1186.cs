using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1186
{
    /// <summary>
    /// 1186. Maximum Subarray Sum with One Deletion - Medium
    /// <a href="https://leetcode.com/problems/maximum-subarray-sum-with-one-deletion">See the problem</a>
    /// </summary>
    public int MaximumSum(int[] arr)
    {
        int n = arr.Length;
        int noDelete = arr[0];       // max sum without deletion
        int oneDelete = arr[0];      // max sum with one deletion
        int maxSum = arr[0];

        for (int i = 1; i < n; i++)
        {
            oneDelete = Math.Max(oneDelete + arr[i], noDelete); // delete current or extend deleted
            noDelete = Math.Max(arr[i], noDelete + arr[i]);     // extend or restart
            maxSum = Math.Max(maxSum, Math.Max(oneDelete, noDelete));
        }

        return maxSum;
    }
}
