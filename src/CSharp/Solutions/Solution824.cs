using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution824
{
    /// <summary>
    /// 824. Goat Latin - Easy
    /// <a href="https://leetcode.com/problems/goat-latin">See the problem</a>
    /// </summary>
    public string ToGoatLatin(string sentence)
    {
        var words = sentence.Split(' ');
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        var result = new StringBuilder();

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            if (vowels.Contains(word[0]))
            {
                result.Append(word);
            }
            else
            {
                result.Append(word[1..]);
                result.Append(word[0]);
            }

            result.Append("ma");
            result.Append('a', i + 1);
            result.Append(' ');
        }

        result.Length--;

        return result.ToString();
    }
}
