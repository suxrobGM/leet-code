namespace LeetCode.Solutions;

public class Solution2342
{
    /// <summary>
    /// 2342. Max Sum of a Pair With Equal Sum of Digits - Medium
    /// <a href="https://leetcode.com/problems/max-sum-of-a-pair-with-equal-sum-of-digits">See the problem</a>
    /// </summary>
    public int MaximumSum(int[] nums)
    {
        // Values are at most 10^9, so their digit sums are at most 81.
        int[] largestByDigitSum = new int[82];
        int maximumSum = -1;

        foreach (int num in nums)
        {
            int digitSum = 0;
            for (int value = num; value > 0; value /= 10)
                digitSum += value % 10;

            // Pair with a previous number before recording the current one.
            if (largestByDigitSum[digitSum] > 0)
                maximumSum = Math.Max(maximumSum, num + largestByDigitSum[digitSum]);

            largestByDigitSum[digitSum] = Math.Max(largestByDigitSum[digitSum], num);
        }

        return maximumSum;
    }
}
