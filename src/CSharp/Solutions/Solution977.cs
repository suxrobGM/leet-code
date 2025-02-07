using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution977
{
    /// <summary>
    /// 977. Squares of a Sorted Array - Easy
    /// <a href="https://leetcode.com/problems/squares-of-a-sorted-array">See the problem</a>
    /// </summary>
    public int[] SortedSquares(int[] nums)
    {
        int n = nums.Length;
        var result = new int[n];

        int left = 0;
        int right = n - 1;

        for (int i = n - 1; i >= 0; i--)
        {
            if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
            {
                result[i] = nums[left] * nums[left];
                left++;
            }
            else
            {
                result[i] = nums[right] * nums[right];
                right--;
            }
        }

        return result;
    }
}
