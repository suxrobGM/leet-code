using System.Text;

namespace LeetCode.Solutions;

public class Solution1807
{
    /// <summary>
    /// 1807. Evaluate the Bracket Pairs of a String - Medium
    /// <a href="https://leetcode.com/problems/evaluate-the-bracket-pairs-of-a-string">See the problem</a>
    /// </summary>
    public string Evaluate(string s, IList<IList<string>> knowledge)
    {
        var dict = new Dictionary<string, string>();
        foreach (var kv in knowledge)
        {
            dict[kv[0]] = kv[1];
        }

        var sb = new StringBuilder();
        int i = 0;
        while (i < s.Length)
        {
            if (s[i] == '(')
            {
                int j = i + 1;
                while (s[j] != ')') j++;
                string key = s.Substring(i + 1, j - i - 1);
                if (dict.ContainsKey(key))
                {
                    sb.Append(dict[key]);
                }
                else
                {
                    sb.Append("?");
                }
                i = j + 1; // move past ')'
            }
            else
            {
                sb.Append(s[i]);
                i++;
            }
        }

        return sb.ToString();
    }
}

