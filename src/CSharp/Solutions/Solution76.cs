using System.Text;

namespace LeetCode.Solutions;

public class Solution76
{
    /// <summary>
    /// 76. Minimum Window Substring
    /// <a href="https://leetcode.com/problems/minimum-window-substring">See the problem</a>
    /// </summary>
    public string MinWindow(string s, string t)
    {
        var tMap = new Dictionary<char, int>();
        var sMap = new Dictionary<char, int>();
        var required = t.Length;
        var left = 0;
        var right = 0;
        var minLen = int.MaxValue;
        var minStart = 0;

        foreach (var letter in t)
        {
            if (!tMap.TryAdd(letter, 1))
            {
                tMap[letter]++;
            }
        }

        while (right < s.Length)
        {
            if (tMap.ContainsKey(s[right]))
            {
                if (!sMap.TryAdd(s[right], 1))
                {
                    sMap[s[right]]++;
                }

                if (sMap[s[right]] <= tMap[s[right]])
                {
                    required--;
                }
            }

            while (required == 0)
            {
                if (right - left + 1 < minLen)
                {
                    minLen = right - left + 1;
                    minStart = left;
                }

                if (tMap.ContainsKey(s[left]))
                {
                    sMap[s[left]]--;

                    if (sMap[s[left]] < tMap[s[left]])
                    {
                        required++;
                    }
                }

                left++;
            }

            right++;
        }

        return minLen == int.MaxValue ? string.Empty : s[minStart..(minStart + minLen)];
    }
}
