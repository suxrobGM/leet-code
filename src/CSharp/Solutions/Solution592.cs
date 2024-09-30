namespace LeetCode.Solutions;

public class Solution592
{
    /// <summary>
    /// 592. Fraction Addition and Subtraction - Medium
    /// <a href="https://leetcode.com/problems/fraction-addition-and-subtraction">See the problem</a>
    /// </summary>
    public string FractionAddition(string expression)
    {
        int numerator = 0;
        int denominator = 1; // Start with denominator as 1

        int i = 0;
        while (i < expression.Length)
        {
            // Determine the sign of the current fraction
            int sign = 1;
            if (expression[i] == '-' || expression[i] == '+')
            {
                sign = (expression[i] == '-') ? -1 : 1;
                i++;
            }

            // Parse the numerator
            int num = 0;
            while (i < expression.Length && char.IsDigit(expression[i]))
            {
                num = num * 10 + (expression[i] - '0');
                i++;
            }
            num *= sign; // Apply the sign to the numerator

            // Skip the '/'
            i++;

            // Parse the denominator
            int denom = 0;
            while (i < expression.Length && char.IsDigit(expression[i]))
            {
                denom = denom * 10 + (expression[i] - '0');
                i++;
            }

            // Add the current fraction (num/denom) to the running total (numerator/denominator)
            numerator = numerator * denom + num * denominator;
            denominator *= denom;

            // Reduce the fraction by GCD
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
        }

        // Return the result in the form "numerator/denominator"
        return numerator + "/" + denominator;
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
