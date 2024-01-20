namespace LeetCode.Solutions;

public class Solution32
{
    /// <summary>
    /// 32. Longest Valid Parentheses
    /// <a href="https://leetcode.com/problems/longest-valid-parentheses">See the problem</a>
    /// </summary>
    public int LongestValidParentheses(string s)
    {
        var maxLength = 0;
        var stack = new Stack<int>();
        stack.Push(-1); // Base for the first valid substring

        for (var i = 0; i < s.Length; i++) 
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            else
            {
                stack.Pop();
                if (stack.Count == 0) 
                {
                    stack.Push(i); // New base for the next valid substring
                } 
                else 
                {
                    maxLength = Math.Max(maxLength, i - stack.Peek());
                }
            }
        }

        return maxLength;
    }
}
