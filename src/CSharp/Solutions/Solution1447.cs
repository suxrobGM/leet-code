namespace LeetCode.Solutions;

public class Solution1447
{
    /// <summary>
    /// 1447. Simplified Fractions - Medium
    /// <a href="https://leetcode.com/problems/simplified-fractions">See the problem</a>
    /// </summary>
    public IList<string> SimplifiedFractions(int n)
    {
        var result = new List<string>();

        for (var denominator = 2; denominator <= n; denominator++)
        {
            for (var numerator = 1; numerator < denominator; numerator++)
            {
                if (GCD(numerator, denominator) == 1)
                {
                    result.Add($"{numerator}/{denominator}");
                }
            }
        }

        return result;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}
