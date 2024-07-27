using System.Text;

namespace LeetCode.Solutions;

public class Solution424
{
    /// <summary>
    /// 424. Longest Repeating Character Replacement - Medium
    /// <a href="https://leetcode.com/problems/longest-repeating-character-replacement">See the problem</a>
    /// </summary>
    public int CharacterReplacement(string s, int k)
    {
        var count = new int[26];
        var maxCount = 0;
        var maxLength = 0;
        var start = 0;

        for (var end = 0; end < s.Length; end++)
        {
            maxCount = Math.Max(maxCount, ++count[s[end] - 'A']);

            while (end - start + 1 - maxCount > k)
            {
                count[s[start] - 'A']--;
                start++;
            }

            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }
}
