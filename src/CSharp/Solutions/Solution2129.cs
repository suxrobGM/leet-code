using System.Text;

namespace LeetCode.Solutions;

public class Solution2129
{
    /// <summary>
    /// 2129. Capitalize the Title - Easy
    /// <a href="https://leetcode.com/problems/capitalize-the-title">See the problem</a>
    /// </summary>
    public string CapitalizeTitle(string title)
    {
        var sb = new StringBuilder();
        var words = title.Split(' ');
        foreach (var word in words)
        {
            if (word.Length <= 2)
            {
                sb.Append(word.ToLower());
            }
            else
            {
                sb.Append(char.ToUpper(word[0]));
                sb.Append(word.Substring(1).ToLower());
            }

            sb.Append(' ');
        }

        return sb.ToString().TrimEnd();
    }
}
