using System.Text;

namespace LeetCode.Solutions;

public class Solution402
{
    /// <summary>
    /// 402. Remove K Digits - Medium
    /// <a href="https://leetcode.com/problems/remove-k-digits">See the problem</a>
    /// </summary>
    public string RemoveKDigits(string num, int k)
    {
        var stack = new Stack<char>();

        foreach (var digit in num)
        {
            while (k > 0 && stack.Count > 0 && stack.Peek() > digit)
            {
                stack.Pop();
                k--;
            }

            stack.Push(digit);
        }

        while (k > 0)
        {
            stack.Pop();
            k--;
        }

        var result = new StringBuilder();

        while (stack.Count > 0)
        {
            result.Insert(0, stack.Pop());
        }

        while (result.Length > 1 && result[0] == '0')
        {
            result.Remove(0, 1);
        }

        return result.Length == 0 ? "0" : result.ToString();
    }
}
