namespace LeetCode.Solutions;

public class Solution224
{
    /// <summary>
    /// 224. Basic Calculator - Hard
    /// <a href="https://leetcode.com/problems/basic-calculator">See the problem</a>
    /// </summary>
    public int Calculate(string s)
    {
        var stack = new Stack<int>();
        var result = 0;
        var number = 0;
        var sign = 1;

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];

            if (char.IsDigit(c))
            {
                number = number * 10 + (c - '0');
            }
            else if (c == '+')
            {
                result += sign * number;
                number = 0;
                sign = 1;
            }
            else if (c == '-')
            {
                result += sign * number;
                number = 0;
                sign = -1;
            }
            else if (c == '(')
            {
                stack.Push(result);
                stack.Push(sign);
                result = 0;
                sign = 1;
            }
            else if (c == ')')
            {
                result += sign * number;
                number = 0;
                result *= stack.Pop();
                result += stack.Pop();
            }
        }

        return result + sign * number;
    }
}
