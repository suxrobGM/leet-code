using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution831
{
    /// <summary>
    /// 831. Masking Personal Information - Medium
    /// <a href="https://leetcode.com/problems/masking-personal-information">See the problem</a>
    /// </summary>
    public string MaskPII(string s)
    {
        if (s.Contains('@'))
        {
            var parts = s.Split('@');
            return $"{parts[0][0]}*****{parts[0][^1]}@{parts[1]}".ToLower();
        }
        else
        {
            var digits = new StringBuilder();
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                {
                    digits.Append(c);
                }
            }

            var result = new StringBuilder();
            var n = digits.Length;
            if (n > 10)
            {
                result.Append('+');
                for (var i = 0; i < n - 10; i++)
                {
                    result.Append('*');
                }

                result.Append('-');
            }

            result.Append("***-***-");
            result.Append(digits.ToString(), n - 4, 4);
            return result.ToString();
        }
    }
}
