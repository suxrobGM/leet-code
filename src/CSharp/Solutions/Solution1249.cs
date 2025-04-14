using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1249
{
    /// <summary>
    /// 1249. Minimum Remove to Make Valid Parentheses - Medium
    /// <a href="https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses">See the problem</a>
    /// </summary>
    public string MinRemoveToMakeValid(string s)
    {
        var stack = new Stack<int>();
        var result = new StringBuilder(s.Length);
        var toRemove = new HashSet<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                stack.Push(i);
            else if (s[i] == ')')
            {
                if (stack.Count > 0)
                    stack.Pop();
                else
                    toRemove.Add(i);
            }
        }

        while (stack.Count > 0)
            toRemove.Add(stack.Pop());

        for (int i = 0; i < s.Length; i++)
        {
            if (!toRemove.Contains(i))
                result.Append(s[i]);
        }

        return result.ToString();
    }
}
