namespace LeetCode.Solutions;

public class Solution263
{
    /// <summary>
    /// 263. Ugly Number - Easy
    /// <a href="https://leetcode.com/problems/ugly-number">See the problem</a>
    /// </summary>
    public bool IsUgly(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        while (n % 2 == 0)
        {
            n /= 2;
        }

        while (n % 3 == 0)
        {
            n /= 3;
        }

        while (n % 5 == 0)
        {
            n /= 5;
        }

        return n == 1;
    }
}
