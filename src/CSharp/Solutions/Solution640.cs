using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution640
{
    /// <summary>
    /// 640. Solve the Equation - Medium
    /// <a href="https://leetcode.com/problems/solve-the-equation">See the problem</a>
    /// </summary>
    public string SolveEquation(string equation)
    {
        var sides = equation.Split('=');
        var left = ParseSide(sides[0]);
        var right = ParseSide(sides[1]);

        // left[0] is coefficient of x, left[1] is the constant term
        // right[0] is coefficient of x, right[1] is the constant term
        var xCoeff = left[0] - right[0];
        var constTerm = right[1] - left[1];

        if (xCoeff == 0)
        {
            if (constTerm == 0)
            {
                return "Infinite solutions";
            }
            else
            {
                return "No solution";
            }
        }

        // One solution case
        return "x=" + (constTerm / xCoeff).ToString();
    }

    private int[] ParseSide(string side)
    {
        var xCoeff = 0;
        var constTerm = 0;
        var sign = 1;
        var i = 0;

        while (i < side.Length)
        {
            if (side[i] == '+')
            {
                sign = 1;
                i++;
            }
            else if (side[i] == '-')
            {
                sign = -1;
                i++;
            }

            var num = 0;
            var hasNum = false;
            while (i < side.Length && char.IsDigit(side[i]))
            {
                num = num * 10 + (side[i] - '0');
                i++;
                hasNum = true;
            }

            if (i < side.Length && side[i] == 'x')
            {
                if (!hasNum)
                {
                    num = 1;  // handle cases like "x" or "-x"
                }
                xCoeff += sign * num;
                i++;  // skip the 'x'
            }
            else
            {
                constTerm += sign * num;
            }
        }

        return [xCoeff, constTerm];
    }
}
