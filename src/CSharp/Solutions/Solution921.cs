using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution921
{
    /// <summary>
    /// 921. Minimum Add to Make Parentheses Valid - Medium
    /// <a href="https://leetcode.com/problems/minimum-add-to-make-parentheses-valid">See the problem</a>
    /// </summary>
    public int MinAddToMakeValid(string s)
    {
        var stack = new Stack<char>();
        var count = 0;

        foreach (var c in s)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count == 0)
                {
                    count++;
                }
                else
                {
                    stack.Pop();
                }
            }
        }
        
        return count + stack.Count;
    }
}
