using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1498
{
    /// <summary>
    /// 1498. Number of Subsequences That Satisfy the Given Sum Condition - Medium
    /// <a href="https://leetcode.com/problems/number-of-subsequences-that-satisfy-the-given-sum-condition">See the problem</a>
    /// </summary>
    public int NumSubseq(int[] nums, int target)
    {
        Array.Sort(nums);
        int left = 0, right = nums.Length - 1;
        int mod = 1_000_000_007;

        // Precompute powers of 2
        var powerOfTwo = new int[nums.Length + 1];
        powerOfTwo[0] = 1;
        for (int i = 1; i <= nums.Length; i++)
        {
            powerOfTwo[i] = (powerOfTwo[i - 1] * 2) % mod;
        }

        int count = 0;
        while (left <= right)
        {
            if (nums[left] + nums[right] <= target)
            {
                count = (count + powerOfTwo[right - left]) % mod;
                left++;
            }
            else
            {
                right--;
            }
        }

        return count;
    }
}
