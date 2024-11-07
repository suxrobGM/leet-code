using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution770
{
    /// <summary>
    /// 770. Basic Calculator IV - Hard
    /// <a href="https://leetcode.com/problems/basic-calculator-iv">See the problem</a>
    /// </summary>
    public IList<string> BasicCalculatorIV(string expression, string[] evalvars, int[] evalints)
    {
        // Substitute evalvars with evalints in the expression map
        var evalMap = new Dictionary<string, int>();
        for (int i = 0; i < evalvars.Length; i++)
        {
            evalMap[evalvars[i]] = evalints[i];
        }

        // Evaluate the expression and obtain the final result as a list of terms
        var result = Evaluate(expression, evalMap);

        // Convert the result to the required output format
        return FormatResult(result);
    }

    private Dictionary<string, int> Evaluate(string expression, Dictionary<string, int> evalMap)
    {
        // Tokenize and recursively evaluate expression with correct operator precedence
        return ParseExpression(expression, evalMap);
    }

    private Dictionary<string, int> ParseExpression(string expression, Dictionary<string, int> evalMap)
    {
        Stack<Dictionary<string, int>> values = new Stack<Dictionary<string, int>>();
        Stack<char> ops = new Stack<char>();
        int i = 0;

        while (i < expression.Length)
        {
            char c = expression[i];
            if (char.IsWhiteSpace(c))
            {
                i++;
                continue;
            }
            else if (char.IsDigit(c) || char.IsLetter(c))
            {
                int start = i;
                while (i < expression.Length && (char.IsDigit(expression[i]) || char.IsLetter(expression[i]))) i++;
                string token = expression.Substring(start, i - start);

                Dictionary<string, int> term;
                if (int.TryParse(token, out int num))
                {
                    term = new Dictionary<string, int> { { "", num } }; // constant term
                }
                else
                {
                    term = new Dictionary<string, int> { { token, evalMap.ContainsKey(token) ? evalMap[token] : 1 } };
                }
                values.Push(term);
            }
            else if (c == '(')
            {
                ops.Push(c);
                i++;
            }
            else if (c == ')')
            {
                while (ops.Peek() != '(')
                {
                    ApplyOperation(values, ops.Pop());
                }
                ops.Pop(); // remove '('
                i++;
            }
            else
            { // operators +, -, *
                while (ops.Count > 0 && Precedence(ops.Peek()) >= Precedence(c))
                {
                    ApplyOperation(values, ops.Pop());
                }
                ops.Push(c);
                i++;
            }
        }

        while (ops.Count > 0)
        {
            ApplyOperation(values, ops.Pop());
        }

        return values.Pop();
    }

    private int Precedence(char op)
    {
        return (op == '+' || op == '-') ? 1 : 2;
    }

    private void ApplyOperation(Stack<Dictionary<string, int>> values, char op)
    {
        var b = values.Pop();
        var a = values.Pop();
        if (op == '+') values.Push(AddTerms(a, b));
        else if (op == '-') values.Push(AddTerms(a, NegateTerms(b)));
        else values.Push(MultiplyTerms(a, b));
    }

    private Dictionary<string, int> AddTerms(Dictionary<string, int> a, Dictionary<string, int> b)
    {
        var result = new Dictionary<string, int>(a);
        foreach (var kv in b)
        {
            if (result.ContainsKey(kv.Key)) result[kv.Key] += kv.Value;
            else result[kv.Key] = kv.Value;
        }
        return result.Where(kv => kv.Value != 0).ToDictionary(kv => kv.Key, kv => kv.Value);
    }

    private Dictionary<string, int> NegateTerms(Dictionary<string, int> terms)
    {
        return terms.ToDictionary(kv => kv.Key, kv => -kv.Value);
    }

    private Dictionary<string, int> MultiplyTerms(Dictionary<string, int> a, Dictionary<string, int> b)
    {
        var result = new Dictionary<string, int>();
        foreach (var kvA in a)
        {
            foreach (var kvB in b)
            {
                var vars = kvA.Key.Split('*').Concat(kvB.Key.Split('*')).Where(v => v != "").OrderBy(x => x).ToArray();
                string newKey = string.Join("*", vars);
                int newValue = kvA.Value * kvB.Value;
                if (result.ContainsKey(newKey)) result[newKey] += newValue;
                else result[newKey] = newValue;
            }
        }
        return result.Where(kv => kv.Value != 0).ToDictionary(kv => kv.Key, kv => kv.Value);
    }

    private IList<string> FormatResult(Dictionary<string, int> terms)
    {
        var sortedTerms = terms
            .OrderByDescending(kv => kv.Key.Count(c => c == '*')) // Sort by degree
            .ThenBy(kv => kv.Key, StringComparer.Ordinal)
            .Select(kv => kv.Value + (kv.Key == "" ? "" : "*" + kv.Key))
            .ToList();

        return sortedTerms;
    }
}
