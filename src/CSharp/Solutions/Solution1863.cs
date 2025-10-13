using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1863
{
    /// <summary>
    /// 1863. Sum of All Subset XOR Totals - Easy
    /// <a href="https://leetcode.com/problems/sum-of-all-subset-xor-totals">See the problem</a>
    /// </summary>
    public int SubsetXORSum(int[] nums)
    {
        int n = nums.Length;
        int totalSubsets = 1 << n; // 2^n subsets
        int totalXorSum = 0;

        for (int subsetMask = 0; subsetMask < totalSubsets; subsetMask++)
        {
            int currentXor = 0;
            for (int j = 0; j < n; j++)
            {
                if ((subsetMask & (1 << j)) != 0)
                {
                    currentXor ^= nums[j];
                }
            }
            totalXorSum += currentXor;
        }

        return totalXorSum;
    }
}
