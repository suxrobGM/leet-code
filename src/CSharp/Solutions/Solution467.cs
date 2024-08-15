using System.Text;

namespace LeetCode.Solutions;

public class Solution467
{
    /// <summary>
    /// 467. Unique Substrings in Wraparound String - Medium
    /// <a href="https://leetcode.com/problems/unique-substrings-in-wraparound-string">See the problem</a>
    /// </summary>
    public int FindSubstringInWraproundString(string s)
    {
        var count = new int[26];
        var maxLength = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (i > 0 && (s[i] - s[i - 1] == 1 || s[i - 1] - s[i] == 25))
            {
                maxLength++;
            }
            else
            {
                maxLength = 1;
            }

            var index = s[i] - 'a';
            count[index] = Math.Max(count[index], maxLength);
        }

        return count.Sum();
    }
}
