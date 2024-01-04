namespace LeetCode.Solutions;

public class Solution20
{
    /// <summary>
    /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    /// An input string is valid if:
    /// 1) Open brackets must be closed by the same type of brackets.
    /// 2) Open brackets must be closed in the correct order.
    /// <see href="https://leetcode.com/problems/valid-parentheses/">See the problem</see>
    /// </summary>
    public bool IsValid(string s)
    {
        if (s.Length <= 1)
            return false;

        var stack = new Stack<char>();

        stack.Push(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            var currentChar = s[i];
            if (stack.Count == 0)
            {
                stack.Push(currentChar);
                continue;
            }

            if (stack.Peek() == '(' && currentChar == ')')
            {
                stack.Pop();
            }
            else if (stack.Peek() == '[' && currentChar == ']')
            {
                stack.Pop();
            }
            else if (stack.Peek() == '{' && currentChar == '}')
            {
                stack.Pop();
            }
            else
            {
                stack.Push(currentChar);
            }
        }
        
        return stack.Count == 0;
    }
}
