using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution557
{
    /// <summary>
    /// 557. Reverse Words in a String III
    /// <a href="https://leetcode.com/problems/reverse-words-in-a-string-iii">See the problem</a>
    /// </summary>
    public string ReverseWords(string s)
    {
        var words = s.Split(' ');
        var sb = new StringBuilder();

        foreach (var word in words)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {
                sb.Append(word[i]);
            }

            sb.Append(' ');
        }

        sb.Length--;

        return sb.ToString();
    }
}
