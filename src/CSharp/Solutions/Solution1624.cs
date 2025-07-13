using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1624
{
    /// <summary>
    /// 1624. Largest Substring Between Two Equal Characters - Easy
    /// <a href="https://leetcode.com/problems/largest-substring-between-two-equal-characters">See the problem</a>
    /// </summary>
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        int maxLength = -1;
        var firstOccurrence = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (firstOccurrence.ContainsKey(c))
            {
                int length = i - firstOccurrence[c] - 1;
                maxLength = Math.Max(maxLength, length);
            }
            else
            {
                firstOccurrence[c] = i;
            }
        }

        return maxLength;
    }
}
