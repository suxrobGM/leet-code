using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1283
{
    /// <summary>
    /// 1283. Find the Smallest Divisor Given a Threshold - Medium
    /// <a href="https://leetcode.com/problems/find-the-smallest-divisor-given-a-threshold">See the problem</a>
    /// </summary>
    public int SmallestDivisor(int[] nums, int threshold)
    {
        int left = 1, right = nums.Max();
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (GetSum(nums, mid) > threshold)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }

    private int GetSum(int[] nums, int divisor)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            sum += (num + divisor - 1) / divisor; // Equivalent to Math.Ceiling((double)num / divisor)
        }
        return sum;
    }
}
