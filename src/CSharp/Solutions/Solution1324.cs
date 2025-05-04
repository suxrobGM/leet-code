using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1324
{
    /// <summar
    /// 1324. Print Words Vertically - Medium
    /// <a href="https://leetcode.com/problems/print-words-vertically">See the problem</a>
    /// </summary>
    public IList<string> PrintVertically(string s)
    {
        var words = s.Split(' ');
        int maxLength = words.Max(w => w.Length);
        var result = new List<string>();

        for (int i = 0; i < maxLength; i++)
        {
            var sb = new StringBuilder();
            foreach (var word in words)
            {
                if (i < word.Length)
                    sb.Append(word[i]);
                else
                    sb.Append(' ');
            }

            // Remove trailing spaces
            result.Add(sb.ToString().TrimEnd());
        }

        return result;
    }
}
