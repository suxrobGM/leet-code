using System.Text;

namespace LeetCode.Solutions;

public class Solution166
{
    /// <summary>
    /// 166. Fraction to Recurring Decimal - Medium
    /// <a href="https://leetcode.com/problems/fraction-to-recurring-decimal">See the problem</a>
    /// </summary>
    public string FractionToDecimal(int numerator, int denominator)
    {
        if (numerator == 0)
        {
            return "0";
        }

        var result = new StringBuilder();

        if (numerator < 0 ^ denominator < 0)
        {
            result.Append('-');
        }

        var dividend = Math.Abs((long)numerator);
        var divisor = Math.Abs((long)denominator);

        result.Append(dividend / divisor);

        var remainder = dividend % divisor;

        if (remainder == 0)
        {
            return result.ToString();
        }

        result.Append('.');

        var map = new Dictionary<long, int>
        {
            [remainder] = result.Length
        };

        while (remainder != 0)
        {
            remainder *= 10;
            result.Append(remainder / divisor);
            remainder %= divisor;

            if (map.ContainsKey(remainder))
            {
                result.Insert(map[remainder], "(");
                result.Append(")");
                break;
            }

            map[remainder] = result.Length;
        }

        return result.ToString();
    }
}
