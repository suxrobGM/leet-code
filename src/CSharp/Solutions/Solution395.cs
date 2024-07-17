using System.Text;

namespace LeetCode.Solutions;

public class Solution395
{
    /// <summary>
    /// 395. Longest Substring with At Least K Repeating Characters - Medium
    /// <a href="https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters">See the problem</a>
    /// </summary>
    public int LongestSubstring(string s, int k)
    {
        var count = new int[26];
        var result = 0;

        for (var i = 1; i <= 26; i++)
        {
            Array.Fill(count, 0);
            int unique = 0;
            int noLessThanK = 0;

            for (int start = 0, end = 0; end < s.Length; end++)
            {
                var index = s[end] - 'a';

                if (count[index] == 0)
                {
                    unique++;
                }

                count[index]++;

                if (count[index] == k)
                {
                    noLessThanK++;
                }

                while (unique > i)
                {
                    index = s[start] - 'a';

                    if (count[index] == k)
                    {
                        noLessThanK--;
                    }

                    count[index]--;

                    if (count[index] == 0)
                    {
                        unique--;
                    }

                    start++;
                }

                if (unique == noLessThanK)
                {
                    result = Math.Max(result, end - start + 1);
                }
            }
        }

        return result;
    }
}
