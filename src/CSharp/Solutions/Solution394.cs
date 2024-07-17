using System.Text;

namespace LeetCode.Solutions;

public class Solution394
{
    /// <summary>
    /// 394. Decode String - Medium
    /// <a href="https://leetcode.com/problems/decode-string">See the problem</a>
    /// </summary>
    public string DecodeString(string s)
    {
        var stack = new Stack<(int, string)>();
        var currentNumber = 0;
        var currentString = new StringBuilder();

        foreach (var c in s)
        {
            if (char.IsDigit(c))
            {
                currentNumber = currentNumber * 10 + (c - '0');
            }
            else if (c == '[')
            {
                stack.Push((currentNumber, currentString.ToString()));
                currentNumber = 0;
                currentString.Clear();
            }
            else if (c == ']')
            {
                var (number, prevString) = stack.Pop();
                var newString = new StringBuilder(prevString);

                for (var i = 0; i < number; i++)
                {
                    newString.Append(currentString);
                }

                currentString = newString;
            }
            else
            {
                currentString.Append(c);
            }
        }

        return currentString.ToString();
    }
}
