using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution736
{
    /// <summary>
    /// 736. Parse Lisp Expression - Hard
    /// <a href="https://leetcode.com/problems/parse-lisp-expression">See the problem</a>
    /// </summary>
    public int Evaluate(string expression)
    {
        return Evaluate(expression, new Stack<Dictionary<string, int>>());
    }

    private int Evaluate(string expression, Stack<Dictionary<string, int>> scope)
    {
        if (char.IsDigit(expression[0]) || expression[0] == '-')
        {
            return int.Parse(expression);
        }
        else if (char.IsLetter(expression[0]))
        {
            // Variable lookup
            foreach (var frame in scope)
            {
                if (frame.ContainsKey(expression))
                {
                    return frame[expression];
                }
            }
            throw new Exception("Variable not found");
        }
        else
        {
            // Remove outermost parentheses
            expression = expression[1..^1];
            string[] tokens = Tokenize(expression);
            if (tokens[0] == "let")
            {
                // Let expression
                var localScope = new Dictionary<string, int>();
                scope.Push(localScope);
                var i = 1;
                for (; i < tokens.Length - 1; i += 2)
                {
                    if (i + 1 == tokens.Length - 1) break; // Last expression without a variable
                    localScope[tokens[i]] = Evaluate(tokens[i + 1], scope);
                }
                int result = Evaluate(tokens[i], scope);
                scope.Pop();
                return result;
            }
            else if (tokens[0] == "add")
            {
                // Add expression
                return Evaluate(tokens[1], scope) + Evaluate(tokens[2], scope);
            }
            else if (tokens[0] == "mult")
            {
                // Mult expression
                return Evaluate(tokens[1], scope) * Evaluate(tokens[2], scope);
            }
        }
        throw new Exception("Invalid expression");
    }

    private string[] Tokenize(string expression)
    {
        var tokens = new List<string>();
        var i = 0;
        while (i < expression.Length)
        {
            if (expression[i] == ' ')
            {
                i++;
            }
            else if (expression[i] == '(')
            {
                int start = i, balance = 1;
                i++;
                while (i < expression.Length && balance > 0)
                {
                    if (expression[i] == '(') balance++;
                    else if (expression[i] == ')') balance--;
                    i++;
                }
                tokens.Add(expression[start..i]);
            }
            else
            {
                int start = i;
                while (i < expression.Length && expression[i] != ' ') i++;
                tokens.Add(expression[start..i]);
            }
        }
        return [.. tokens];
    }
}
