namespace LeetCode.Solutions;

public class Solution1979
{
    /// <summary>
    /// 1979. Find Greatest Common Divisor of Array - Easy
    /// <a href="https://leetcode.com/problems/find-greatest-common-divisor-of-array">See the problem</a>
    /// </summary>
    public int FindGCD(int[] nums)
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        foreach (var num in nums)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }

        return GCD(min, max);
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
