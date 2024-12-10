using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution891
{
    /// <summary>
    /// 891. Sum of Subsequence Widths - Hard
    /// <a href="https://leetcode.com/problems/sum-of-subsequence-widths">See the problem</a>
    /// </summary>
    public int SumSubseqWidths(int[] nums)
    {
        const int MOD = 1_000_000_007;
        int n = nums.Length;

        // Sort the array
        Array.Sort(nums);

        // Precompute powers of 2 modulo MOD
        long[] powerOfTwo = new long[n];
        powerOfTwo[0] = 1;
        for (int i = 1; i < n; i++)
        {
            powerOfTwo[i] = powerOfTwo[i - 1] * 2 % MOD;
        }

        long result = 0;

        // Calculate contribution of each element
        for (int i = 0; i < n; i++)
        {
            long maxContribution = nums[i] * powerOfTwo[i] % MOD;
            long minContribution = nums[i] * powerOfTwo[n - i - 1] % MOD;
            result = (result + maxContribution - minContribution + MOD) % MOD;
        }

        return (int)result;
    }
}
