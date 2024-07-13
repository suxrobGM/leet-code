namespace LeetCode.Solutions;

public class Solution371
{
    /// <summary>
    /// 371. Sum of Two Integers - Medium
    /// <a href="https://leetcode.com/problems/sum-of-two-integers">See the problem</a>
    /// </summary>
    public int GetSum(int a, int b)
    {
        while (b != 0)
        {
            var carry = a & b;
            a ^= b;
            b = carry << 1;
        }

        return a;
    }
}
