namespace LeetCode.Solutions;

public class Solution151
{
    /// <summary>
    /// 151. Reverse Words in a String
    /// <a href="https://leetcode.com/problems/reverse-words-in-a-string">See the problem</a>
    /// </summary>
    public string ReverseWords(string s)
    {
        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);
        return string.Join(' ', words);
    }
}
