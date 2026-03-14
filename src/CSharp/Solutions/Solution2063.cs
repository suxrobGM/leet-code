namespace LeetCode.Solutions;

public class Solution2063
{
    /// <summary>
    /// 2063. Vowels of All Substrings - Medium
    /// <a href="https://leetcode.com/problems/vowels-of-all-substrings">See the problem</a>
    /// </summary>
    public long CountVowels(string word)
    {
        var count = 0L;
        var vowels = "aeiou";

        for (var i = 0; i < word.Length; i++)
        {
            if (vowels.Contains(word[i]))
            {
                count += (long)(i + 1) * (word.Length - i);
            }
        }

        return count;
    }
}
