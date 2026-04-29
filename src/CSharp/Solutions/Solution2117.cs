using System.Numerics;

namespace LeetCode.Solutions;

public class Solution2117
{
    /// <summary>
    /// 2117. Abbreviating the Product of a Range - Hard
    /// <a href="https://leetcode.com/problems/abbreviating-the-product-of-a-range">See the problem</a>
    /// </summary>
    public string AbbreviateProduct(int left, int right)
    {
        const long mod = 100000000000L;
        var headCap = BigInteger.Pow(10, 25);
        long count2 = 0, count5 = 0;
        long suffix = 1;
        var head = BigInteger.One;
        double logSum = 0;

        for (var i = left; i <= right; i++)
        {
            logSum += Math.Log10(i);
            head *= i;
            while (head >= headCap) head /= 10;
            var x = i;
            while (x % 2 == 0) { x /= 2; count2++; }
            while (x % 5 == 0) { x /= 5; count5++; }
            suffix = suffix * x % mod;
        }

        var c = Math.Min(count2, count5);
        for (long i = 0; i < count2 - c; i++) suffix = suffix * 2 % mod;
        for (long i = 0; i < count5 - c; i++) suffix = suffix * 5 % mod;

        if (logSum - c < 10)
        {
            return $"{suffix}e{c}";
        }

        while (head >= 100000) head /= 10;
        var last5 = suffix % 100000;
        return $"{head}...{last5:D5}e{c}";
    }
}
