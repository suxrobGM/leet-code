using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution633
{
    /// <summary>
    /// 633. Sum of Square Numbers - Medium
    /// <a href="https://leetcode.com/problems/sum-of-square-numbers">See the problem</a>
    /// </summary>
    public bool JudgeSquareSum(int c)
    {
        long a = 0;
        long b = (long)Math.Sqrt(c); // Start b from sqrt(c)

        while (a <= b)
        {
            long sum = a * a + b * b;

            if (sum == c)
            {
                return true; // Found a and b such that a^2 + b^2 = c
            }
            else if (sum > c)
            {
                b--; // Decrease b since sum is too large
            }
            else
            {
                a++; // Increase a since sum is too small
            }
        }

        return false; // No such pair found
    }
}
