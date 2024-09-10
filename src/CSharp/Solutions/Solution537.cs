using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution537
{
    /// <summary>
    /// 537. Complex Number Multiplication - Medium
    /// <a href="https://leetcode.com/problems/complex-number-multiplication">See the problem</a>
    /// </summary>
    public string ComplexNumberMultiply(string num1, string num2)
    {
        var complex1 = ParseComplexNumber(num1);
        var complex2 = ParseComplexNumber(num2);

        var real = complex1.Real * complex2.Real - complex1.Imaginary * complex2.Imaginary;
        var imaginary = complex1.Real * complex2.Imaginary + complex1.Imaginary * complex2.Real;

        return $"{real}+{imaginary}i";
    }

    private ComplexNumber ParseComplexNumber(string num)
    {
        var parts = num.Split('+');
        return new ComplexNumber(int.Parse(parts[0]), int.Parse(parts[1].Substring(0, parts[1].Length - 1)));
    }

    private class ComplexNumber
    {
        public int Real { get; }
        public int Imaginary { get; }

        public ComplexNumber(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
    }
}
