using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1941
{
    /// <summary>
    /// 1941. Check if All Characters Have Equal Number of Occurrences - Easy
    /// <a href="https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences">See the problem</a>
    /// </summary>
    public bool AreOccurrencesEqual(string s)
    {
        var charCount = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (!charCount.ContainsKey(c))
            {
                charCount[c] = 0;
            }
            charCount[c]++;
        }

        int firstCount = charCount[s[0]];
        foreach (int count in charCount.Values)
        {
            if (count != firstCount)
            {
                return false;
            }
        }
        return true;
    }
}
