using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1343
{
    /// <summary>
    /// 1343. Number of Sub-arrays of Size K and Average Greater than or Equal to Threshold - Medium
    /// <a href="https://leetcode.com/problems/number-of-sub-arrays-of-size-k-and-average-greater-than-or-equal-to-threshold">See the problem</a>
    /// </summary>
    public int NumOfSubarrays(int[] arr, int k, int threshold)
    {
        int n = arr.Length;
        int sum = 0;
        int count = 0;

        // Calculate the sum of the first k elements
        for (int i = 0; i < k; i++)
        {
            sum += arr[i];
        }

        // Check if the average of the first k elements is greater than or equal to threshold
        if (sum >= k * threshold)
        {
            count++;
        }

        // Slide the window over the rest of the array
        for (int i = k; i < n; i++)
        {
            sum += arr[i] - arr[i - k]; // Update the sum by adding the new element and removing the old one

            if (sum >= k * threshold)
            {
                count++;
            }
        }

        return count;
    }
}
