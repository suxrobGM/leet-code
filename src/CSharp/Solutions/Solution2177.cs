namespace LeetCode.Solutions;

public class Solution2177
{
    /// <summary>
    /// 2177. Find Three Consecutive Integers That Sum to a Given Number - Medium
    /// <a href="https://leetcode.com/problems/find-three-consecutive-integers-that-sum-to-a-given-number">See the problem</a>
    /// </summary>
    public long[] SumOfThree(long num)
    {
        if (num % 3 != 0)
        {
            return new long[0];
        }

        long middle = num / 3;
        return new long[] { middle - 1, middle, middle + 1 };
    }
}
