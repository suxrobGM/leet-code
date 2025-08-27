using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1763
{
    /// <summary>
    /// 1763. Longest Nice Substring - Easy
    /// <a href="https://leetcode.com/problems/longest-nice-substring">See the problem</a>
    /// </summary>
    public string LongestNiceSubstring(string s)
    {
        return Helper(s);
    }

    private string Helper(string s)
    {
        if (s.Length < 2) return "";

        var set = new HashSet<char>(s);
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (!(set.Contains(char.ToLower(c)) && set.Contains(char.ToUpper(c))))
            {
                string left = Helper(s.Substring(0, i));
                string right = Helper(s.Substring(i + 1));
                if (left.Length >= right.Length) return left;
                return right;
            }
        }
        return s; // whole string is nice
    }
}
