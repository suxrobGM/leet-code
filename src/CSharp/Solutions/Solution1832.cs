using System.Text;

namespace LeetCode.Solutions;

public class Solution1832
{
    const int MOD = 1_000_000_007;

    /// <summary>
    /// 1832. Check if the Sentence Is Pangram - Easy
    /// <a href="https://leetcode.com/problems/check-if-the-sentence-is-pangram">See the problem</a>
    /// </summary>
    public bool CheckIfPangram(string sentence)
    {
        if (sentence.Length < 26) return false;

        bool[] seen = new bool[26];
        foreach (char ch in sentence)
        {
            seen[ch - 'a'] = true;
        }

        foreach (bool b in seen)
        {
            if (!b) return false;
        }

        return true;
    }
}
