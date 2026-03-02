namespace LeetCode.Solutions;

public class Solution2048
{
    /// <summary>
    /// 2048. Next Greater Numerically Balanced Number - Medium
    /// <a href="https://leetcode.com/problems/next-greater-numerically-balanced-number">See the problem</a>
    /// </summary>
    public int NextBeautifulNumber(int n)
    {
        while (true)
        {
            n++;
            if (IsBalanced(n))
                return n;
        }
    }

    private static bool IsBalanced(int n)
    {
        Span<int> count = stackalloc int[10];
        while (n > 0)
        {
            count[n % 10]++;
            n /= 10;
        }

        for (var d = 0; d < 10; d++)
        {
            if (count[d] != 0 && count[d] != d)
                return false;
        }

        return true;
    }
}
