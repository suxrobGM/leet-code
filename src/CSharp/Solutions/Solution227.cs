using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution227
{
    /// <summary>
    /// 227. Basic Calculator II - Medium
    /// <a href="https://leetcode.com/problems/basic-calculator-ii">See the problem</a>
    /// </summary>
    public int Calculate(string s)
    {
        var stack = new Stack<int>();
        var num = 0;
        var sign = '+';

        for (var i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                num = num * 10 + s[i] - '0';
            }

            if ((!char.IsDigit(s[i]) && s[i] != ' ') || i == s.Length - 1)
            {
                if (sign == '+')
                {
                    stack.Push(num);
                }
                else if (sign == '-')
                {
                    stack.Push(-num);
                }
                else if (sign == '*')
                {
                    stack.Push(stack.Pop() * num);
                }
                else if (sign == '/')
                {
                    stack.Push(stack.Pop() / num);
                }

                sign = s[i];
                num = 0;
            }
        }

        return stack.Sum();
    }
}
