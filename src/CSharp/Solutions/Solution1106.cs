using System.Text;

namespace LeetCode.Solutions;

public class Solution1106
{
    /// <summary>
    /// 1106. Parsing A Boolean Expression - Hard
    /// <a href="https://leetcode.com/problems/parsing-a-boolean-expression">See the problem</a>
    /// </summary>
    public bool ParseBoolExpr(string expression)
    {
        var stack = new Stack<char>();
        foreach (var c in expression)
        {
            if (c == ')')
            {
                var seen = new HashSet<char>();
                while (stack.Peek() != '(')
                {
                    seen.Add(stack.Pop());
                }
                stack.Pop(); // pop '('
                var op = stack.Pop(); // pop operator
                if (op == '&')
                {
                    stack.Push(seen.Contains('f') ? 'f' : 't');
                }
                else if (op == '|')
                {
                    stack.Push(seen.Contains('t') ? 't' : 'f');
                }
                else if (op == '!')
                {
                    stack.Push(seen.Contains('t') ? 'f' : 't');
                }
            }
            else if (c != ',')
            {
                stack.Push(c);
            }
        }
        return stack.Pop() == 't';
    }
}
