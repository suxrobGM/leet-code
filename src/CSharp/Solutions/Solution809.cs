using System.Text;

namespace LeetCode.Solutions;

public class Solution809
{
    /// <summary>
    /// 809. Expressive Words - Medium
    /// <a href="https://leetcode.com/problems/expressive-words">See the problem</a>
    /// </summary>
    public int ExpressiveWords(string s, string[] words)
    {
        var result = 0;

        foreach (var word in words)
        {
            if (IsExpressive(s, word))
            {
                result++;
            }
        }

        return result;
    }

    private bool IsExpressive(string s, string word)
    {
        var i = 0;
        var j = 0;

        while (i < s.Length && j < word.Length)
        {
            if (s[i] != word[j])
            {
                return false;
            }

            var countS = 1;
            var countWord = 1;

            while (i + 1 < s.Length && s[i] == s[i + 1])
            {
                i++;
                countS++;
            }

            while (j + 1 < word.Length && word[j] == word[j + 1])
            {
                j++;
                countWord++;
            }

            if (countS < countWord || (countS != countWord && countS < 3))
            {
                return false;
            }

            i++;
            j++;
        }

        return i == s.Length && j == word.Length;
    }
}
