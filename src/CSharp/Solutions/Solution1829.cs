using System.Text;

namespace LeetCode.Solutions;

public class Solution1829
{
    /// <summary>
    /// 1829. Maximum XOR for Each Query - Medium
    /// <a href="https://leetcode.com/problems/maximum-xor-for-each-query">See the problem</a>
    /// </summary>
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        int n = nums.Length;
        int[] result = new int[n];
        int mask = (1 << maximumBit) - 1; // Create a mask with maximumBit bits set to 1
        int currentXor = 0;

        // Calculate the cumulative XOR of all elements in nums
        foreach (var num in nums)
        {
            currentXor ^= num;
        }

        // Process each query in reverse order
        for (int i = n - 1; i >= 0; i--)
        {
            // The value to maximize the XOR is the complement of currentXor within the mask
            result[i] = currentXor ^ mask;
            // Update currentXor by removing the last element of nums
            currentXor ^= nums[i];
        }

        Array.Reverse(result);
        return result;
    }
}
