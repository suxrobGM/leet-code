using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1300
{
    /// <summary>
    /// 1300. Sum of Mutated Array Closest to Target - Medium
    /// <a href="https://leetcode.com/problems/sum-of-mutated-array-closest-to-target">See the problem</a>
    /// </summary>
    public int FindBestValue(int[] arr, int target)
    {
        int left = 0, right = arr.Max();
        int bestValue = 0;
        int bestDiff = int.MaxValue;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int sum = GetCappedSum(arr, mid);

            int diff = Math.Abs(sum - target);

            if (diff < bestDiff || (diff == bestDiff && mid < bestValue))
            {
                bestDiff = diff;
                bestValue = mid;
            }

            if (sum < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return bestValue;
    }

    private int GetCappedSum(int[] arr, int cap)
    {
        int sum = 0;
        foreach (var num in arr)
        {
            sum += Math.Min(num, cap);
        }
        return sum;
    }
}
