using System.Text;

namespace LeetCode.Solutions;

public class Solution1844
{
    /// <summary>
    /// 1844. Replace All Digits with Characters - Easy
    /// <a href="https://leetcode.com/problems/replace-all-digits-with-characters">See the problem</a>
    /// </summary>
    public string ReplaceDigits(string s)
    {
        var sb = new StringBuilder(s);

        for (int i = 1; i < sb.Length; i += 2)
        {
            char ch = sb[i - 1];
            int digit = sb[i] - '0';
            sb[i] = (char)(ch + digit);
        }

        return sb.ToString();
    }
}
