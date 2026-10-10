using System.Text;

namespace LeetCode.Solutions;

public class Solution2309
{
    /// <summary>
    /// 2309. Greatest English Letter in Upper and Lower Case - Easy
    /// <a href="https://leetcode.com/problems/greatest-english-letter-in-upper-and-lower-case">See the problem</a>
    /// </summary>
    public string GreatestLetter(string s)
    {
        var lower = new HashSet<char>();
        var upper = new HashSet<char>();

        foreach (var c in s)
        {
            if (char.IsLower(c))
            {
                lower.Add(c);
            }
            else
            {
                upper.Add(c);
            }
        }

        for (char c = 'Z'; c >= 'A'; c--)
        {
            if (upper.Contains(c) && lower.Contains(char.ToLower(c)))
            {
                return c.ToString();
            }
        }

        return string.Empty;
    }
}
