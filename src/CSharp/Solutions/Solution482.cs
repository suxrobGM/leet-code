using System.Text;

namespace LeetCode.Solutions;

public class Solution482
{
    /// <summary>
    /// 482. License Key Formatting - Easy
    /// <a href="https://leetcode.com/problems/license-key-formatting">See the problem</a>
    /// </summary>
    public string LicenseKeyFormatting(string s, int k)
    {
        var sb = new StringBuilder();
        var count = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '-') continue;

            if (count == k)
            {
                sb.Append('-');
                count = 0;
            }

            sb.Append(char.ToUpper(s[i]));
            count++;
        }

        return new string(sb.ToString().Reverse().ToArray());
    }
}
