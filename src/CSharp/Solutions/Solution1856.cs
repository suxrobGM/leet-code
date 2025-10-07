using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1856
{
    /// <summary>
    /// 1856. Maximum Subarray Min-Product - Medium
    /// <a href="https://leetcode.com/problems/maximum-subarray-min-product">See the problem</a>
    /// </summary>
    public int MaxSumMinProduct(int[] nums)
    {
        int n = nums.Length;
        long[] prefixSum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        var stack = new Stack<int>();
        long maxMinProduct = 0;
        for (int i = 0; i <= n; i++)
        {
            while (stack.Count > 0 && (i == n || nums[stack.Peek()] >= nums[i]))
            {
                int minIndex = stack.Pop();
                int leftIndex = stack.Count > 0 ? stack.Peek() : -1;
                long sum = prefixSum[i] - prefixSum[leftIndex + 1];
                maxMinProduct = Math.Max(maxMinProduct, sum * nums[minIndex]);
            }
            stack.Push(i);
        }

        return (int)(maxMinProduct % 1_000_000_007);
    }
}
