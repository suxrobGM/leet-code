using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution966
{
    /// <summary>
    /// 966. Vowel Spellchecker - Medium
    /// <a href="https://leetcode.com/problems/vowel-spellchecker">See the problem</a>
    /// </summary>
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        var words = new HashSet<string>(wordlist);
        var lower = new Dictionary<string, string>();
        var vowel = new Dictionary<string, string>();

        foreach (var word in wordlist)
        {
            var lowerWord = word.ToLower();
            var vowelWord = ReplaceVowels(lowerWord);

            if (!lower.ContainsKey(lowerWord))
            {
                lower[lowerWord] = word;
            }

            if (!vowel.ContainsKey(vowelWord))
            {
                vowel[vowelWord] = word;
            }
        }

        var result = new string[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var lowerQuery = query.ToLower();
            var vowelQuery = ReplaceVowels(lowerQuery);

            if (words.Contains(query))
            {
                result[i] = query;
            }
            else if (lower.ContainsKey(lowerQuery))
            {
                result[i] = lower[lowerQuery];
            }
            else if (vowel.ContainsKey(vowelQuery))
            {
                result[i] = vowel[vowelQuery];
            }
            else
            {
                result[i] = "";
            }
        }

        return result;
    }

    private string ReplaceVowels(string word)
    {
        var sb = new StringBuilder();
        foreach (var c in word)
        {
            sb.Append(IsVowel(c) ? '*' : c);
        }

        return sb.ToString();
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}
