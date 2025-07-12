using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1619
{
    /// <summary>
    /// 1619. Mean of Array After Removing Some Elements - Easy
    /// <a href="https://leetcode.com/problems/mean-of-array-after-removing-some-elements">See the problem</a>
    /// </summary>
    public double TrimMean(int[] arr)
    {
        Array.Sort(arr);
        int n = arr.Length;
        int toRemove = n / 20; // 5% of the array
        double sum = 0;

        // Calculate the sum excluding the first and last 5% of elements
        for (int i = toRemove; i < n - toRemove; i++)
        {
            sum += arr[i];
        }

        // Calculate the mean
        return sum / (n - 2 * toRemove);
    }
}
