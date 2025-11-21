using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1911
{
    /// <summary>
    /// 1911. Maximum Alternating Subsequence Sum - Medium
    /// <a href="https://leetcode.com/problems/maximum-alternating-subsequence-sum">See the problem</a>
    /// </summary>
    public long MaxAlternatingSum(int[] nums)
    {
        long evenSum = 0;
        long oddSum = 0;

        foreach (var num in nums)
        {
            long newEvenSum = Math.Max(evenSum, oddSum + num);
            long newOddSum = Math.Max(oddSum, evenSum - num);

            evenSum = newEvenSum;
            oddSum = newOddSum;
        }

        return evenSum;
    }
}
