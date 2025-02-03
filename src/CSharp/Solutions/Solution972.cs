using System.Numerics;
using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution972
{
    /// <summary>
    /// 972. Equal Rational Numbers - Hard
    /// <a href="https://leetcode.com/problems/equal-rational-numbers">See the problem</a>
    /// </summary>
    public bool IsRationalEqual(string s, string t)
    {
        (BigInteger num1, BigInteger den1) = ConvertToFraction(s);
        (BigInteger num2, BigInteger den2) = ConvertToFraction(t);
        return num1 * den2 == num2 * den1;
    }

    private (BigInteger, BigInteger) ConvertToFraction(string num)
    {
        if (!num.Contains('(')) return ConvertNonRepeatingToFraction(num);

        int openParen = num.IndexOf('(');
        string basePart = num.Substring(0, openParen);
        string repeatingPart = num.Substring(openParen + 1, num.Length - openParen - 2);

        (BigInteger baseNum, BigInteger baseDen) = ConvertNonRepeatingToFraction(basePart);

        // If there's no repeating part, return the base fraction
        if (repeatingPart.Length == 0) return (baseNum, baseDen);

        var repeatNum = BigInteger.Parse(repeatingPart);
        var repeatDen = BigInteger.Pow(10, repeatingPart.Length) - 1;
        var shift = BigInteger.Pow(10, basePart.Contains('.') ? basePart.Length - basePart.IndexOf('.') - 1 : 0);

        // Adjust fraction for repeating part
        var numerator = baseNum * repeatDen + repeatNum;
        var denominator = baseDen * repeatDen;

        // Reduce fraction
        var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
        return (numerator / gcd, denominator / gcd);
    }

    private (BigInteger, BigInteger) ConvertNonRepeatingToFraction(string num)
    {
        if (!num.Contains('.')) return (BigInteger.Parse(num), 1);

        string[] parts = num.Split('.');
        var integerPart = BigInteger.Parse(parts[0]);
        var decimalPart = BigInteger.Parse(parts[1]);

        var decimalPlaces = BigInteger.Pow(10, parts[1].Length);
        var numerator = integerPart * decimalPlaces + decimalPart;
        var denominator = decimalPlaces;

        var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
        return (numerator / gcd, denominator / gcd);
    }
}
