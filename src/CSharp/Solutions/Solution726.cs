using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution726
{
    /// <summary>
    /// 726. Number of Atoms - Hard
    /// <a href="https://leetcode.com/problems/number-of-atoms">See the problem</a>
    /// </summary>
    public string CountOfAtoms(string formula)
    {
        var i = formula.Length - 1;
        var stack = new Stack<Dictionary<string, int>>();
        stack.Push([]);

        while (i >= 0)
        {
            if (formula[i] == ')')
            {
                stack.Push([]);
                i--;
            }
            else if (formula[i] == '(')
            {
                var top = stack.Pop();
                var multiplier = ParseNumber(formula, ref i);

                foreach (var atom in top)
                {
                    if (!stack.Peek().ContainsKey(atom.Key))
                    {
                        stack.Peek()[atom.Key] = 0;
                    }
                    stack.Peek()[atom.Key] += atom.Value * multiplier;
                }
                i--;
            }
            else
            {
                var atom = ParseAtom(formula, ref i);
                var count = ParseNumber(formula, ref i);
                if (!stack.Peek().ContainsKey(atom))
                {
                    stack.Peek()[atom] = 0;
                }
                stack.Peek()[atom] += count;
            }
        }

        var atomCounts = stack.Pop();
        var sortedAtoms = new List<string>(atomCounts.Keys);
        sortedAtoms.Sort();
        var result = new StringBuilder();

        foreach (var atom in sortedAtoms)
        {
            result.Append(atom);
            if (atomCounts[atom] > 1)
            {
                result.Append(atomCounts[atom]);
            }
        }

        return result.ToString();
    }

    private string ParseAtom(string formula, ref int i)
    {
        int start = i;
        i--;
        while (i >= 0 && char.IsLower(formula[i]))
        {
            i--;
        }
        return formula.Substring(i + 1, start - i);
    }

    private int ParseNumber(string formula, ref int i)
    {
        if (i < 0 || !char.IsDigit(formula[i])) return 1;
        var start = i;

        while (i >= 0 && char.IsDigit(formula[i]))
        {
            i--;
        }
        return int.Parse(formula.Substring(i + 1, start - i));
    }
}
