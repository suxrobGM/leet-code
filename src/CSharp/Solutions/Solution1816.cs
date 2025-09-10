using System.Text;

namespace LeetCode.Solutions;

public class Solution1816
{
    /// <summary>
    /// 1816. Truncate Sentence - Easy
    /// <a href="https://leetcode.com/problems/truncate-sentence">See the problem</a>
    /// </summary>
    public string TruncateSentence(string s, int k)
    {
        var words = s.Split(' ');
        return string.Join(' ', words.Take(k));
    }
}
