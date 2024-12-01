using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution856
{
    /// <summary>
    /// 856. Score of Parentheses - Medium
    /// <a href="https://leetcode.com/problems/score-of-parentheses">See the problem</a>
    /// </summary>
    public int ScoreOfParentheses(string s)
    {
        var stack = new Stack<int>();
        stack.Push(0);

        foreach (var c in s)
        {
            if (c == '(')
            {
                stack.Push(0);
            }
            else
            {
                var v = stack.Pop();
                var w = stack.Pop();
                stack.Push(w + Math.Max(2 * v, 1));
            }
        }

        return stack.Pop();
    }
}
