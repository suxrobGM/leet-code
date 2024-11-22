using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution844
{
    /// <summary>
    /// 844. Backspace String Compare - Easy
    /// <a href="https://leetcode.com/problems/backspace-string-compare">See the problem</a>
    /// </summary>
    public bool BackspaceCompare(string s, string t)
    {
        return Process(s) == Process(t);
    }

    private string Process(string s)
    {
        var result = new StringBuilder();
        foreach (char c in s)
        {
            if (c == '#')
            {
                if (result.Length > 0)
                {
                    result.Length--;
                }
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
}
