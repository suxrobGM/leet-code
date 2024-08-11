using System.Text;

namespace LeetCode.Solutions;

public class Solution459
{
    /// <summary>
    /// 459. Repeated Substring Pattern - Easy
    /// <a href="https://leetcode.com/problems/repeated-substring-pattern">See the problem</a>
    /// </summary>
    public bool RepeatedSubstringPattern(string s) 
    {
        var n = s.Length;
        for (var i = 1; i <= n / 2; i++)
        {
            if (n % i == 0) // i is a factor of n
            {
                var pattern = s[..i];
                var sb = new StringBuilder();

                for (int j = 0; j < n / i; j++)
                {
                    sb.Append(pattern);
                }

                if (sb.ToString() == s)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
