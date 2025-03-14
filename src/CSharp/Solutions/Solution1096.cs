using System.Text;

namespace LeetCode.Solutions;

public class Solution1096
{
    /// <summary>
    /// 1096. Brace Expansion II - Hard
    /// <a href="https://leetcode.com/problems/brace-expansion-ii">See the problem</a>
    /// </summary>
    public IList<string> BraceExpansionII(string expression)
    {
        var stack = new Stack<HashSet<string>>();
        var opStack = new Stack<char>();
        var currSet = new HashSet<string> { "" };

        for (int i = 0; i < expression.Length; i++)
        {
            char ch = expression[i];

            if (ch == '{')
            {
                stack.Push(currSet);
                opStack.Push(ch);
                currSet = [""]; // Reset for the new block
            }
            else if (ch == '}')
            {
                var tempSet = currSet;
                while (opStack.Count > 0 && opStack.Peek() != '{')
                {
                    tempSet = Union(stack.Pop(), tempSet);
                    opStack.Pop();
                }
                opStack.Pop(); // Remove the '{'
                currSet = Concatenate(stack.Pop(), tempSet);
            }
            else if (ch == ',')
            {
                stack.Push(currSet);
                opStack.Push(ch);
                currSet = [""]; // Reset for union operation
            }
            else
            {
                int j = i;
                while (j < expression.Length && Char.IsLetter(expression[j])) j++;
                var word = expression.Substring(i, j - i);
                currSet = Concatenate(currSet, [word]);
                i = j - 1;
            }
        }

        while (opStack.Count > 0)
        {
            currSet = Union(stack.Pop(), currSet);
            opStack.Pop();
        }

        var result = currSet.ToList();
        result.Sort();
        return result;
    }

    // Union combines two sets.
    private HashSet<string> Union(HashSet<string> set1, HashSet<string> set2)
    {
        set1.UnionWith(set2);
        return set1;
    }

    // Concatenate generates all possible combinations of strings from two sets.
    private HashSet<string> Concatenate(HashSet<string> set1, HashSet<string> set2)
    {
        var result = new HashSet<string>();
        foreach (string s1 in set1)
        {
            foreach (string s2 in set2)
            {
                result.Add(s1 + s2);
            }
        }
        return result;
    }
}
