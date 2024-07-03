using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution301
{
    /// <summary>
    /// 301. Remove Invalid Parentheses - Hard
    /// <a href="https://leetcode.com/problems/remove-invalid-parentheses">See the problem</a>
    /// </summary>
    public IList<string> RemoveInvalidParentheses(string s)
    {
        var result = new List<string>();
        Remove(s, result, 0, 0, ['(', ')']);
        return result;
    }

    private void Remove(string s, List<string> result, int lastI, int lastJ, char[] par)
    {
        for (int stack = 0, i = lastI; i < s.Length; i++)
        {
            if (s[i] == par[0])
            {
                stack++;
            }
            if (s[i] == par[1])
            {
                stack--;
            }
            if (stack >= 0)
            {
                continue;
            }
            for (var j = lastJ; j <= i; j++)
            {
                if (s[j] == par[1] && (j == lastJ || s[j - 1] != par[1]))
                {
                    Remove(s[0..j] + s[(j + 1)..], result, i, j, par);
                }
            }
            return;
        }
        
        var reversed = new string(s.Reverse().ToArray());
        if (par[0] == '(')
        {
            Remove(reversed, result, 0, 0, new[] { ')', '(' });
        }
        else
        {
            result.Add(reversed);
        }
    }
}
