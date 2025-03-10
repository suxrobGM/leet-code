using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1078
{
    /// <summary>
    /// 1078. Occurrences After Bigram - Easy
    /// <a href="https://leetcode.com/problems/occurrences-after-bigram"</a>
    /// </summary>
    public string[] FindOcurrences(string text, string first, string second)
    {
        var words = text.Split(' ');
        var result = new List<string>();

        for (int i = 0; i < words.Length - 2; i++)
        {
            if (words[i] == first && words[i + 1] == second)
            {
                result.Add(words[i + 2]);
            }
        }

        return [.. result];
    }
}
