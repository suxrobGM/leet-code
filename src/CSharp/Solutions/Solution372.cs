namespace LeetCode.Solutions;

public class Solution372
{
    /// <summary>
    /// 372. Super Pow - Medium
    /// <a href="https://leetcode.com/problems/super-pow">See the problem</a>
    /// </summary>
    public int SuperPow(int a, int[] b)
    {
        var result = 1;
        var mod = 1337;

        for (var i = 0; i < b.Length; i++)
        {
            result = Pow(result, 10, mod) * Pow(a, b[i], mod) % mod;
        }

        return result;
    }

    private int Pow(int a, int b, int mod)
    {
        if (b == 0)
        {
            return 1;
        }

        a %= mod;

        var result = 1;

        for (var i = 0; i < b; i++)
        {
            result = (result * a) % mod;
        }

        return result;
    }
}
