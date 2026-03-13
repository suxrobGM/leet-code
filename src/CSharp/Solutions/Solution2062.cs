namespace LeetCode.Solutions;

public class Solution2062
{
    /// <summary>
    /// 2062. Count Vowel Substrings of a String - Easy
    /// <a href="https://leetcode.com/problems/count-vowel-substrings-of-a-string">See the problem</a>
    /// </summary>
    public int CountVowelSubstrings(string word)
    {
        var count = 0;
        var vowels = "aeiou";

        for (var i = 0; i < word.Length; i++)
        {
            var seen = new HashSet<char>();
            for (var j = i; j < word.Length; j++)
            {
                if (!vowels.Contains(word[j])) break;
                seen.Add(word[j]);
                if (seen.Count == 5) count++;
            }
        }

        return count;
    }
}
