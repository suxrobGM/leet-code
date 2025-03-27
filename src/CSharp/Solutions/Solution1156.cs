using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1156
{
    /// <summary>
    /// 1156. Swap For Longest Repeated Character Substring - Medium
    /// <a href="https://leetcode.com/problems/swap-for-longest-repeated-character-substring">See the problem</a>
    /// </summary>
    public int MaxRepOpt1(string text)
    {
        int n = text.Length;
        var freq = new int[26];

        foreach (var ch in text)
        {
            freq[ch - 'a']++;
        }

        var maxLen = 0;

        for (var i = 0; i < n;)
        {
            var ch = text[i];
            var j = i;

            // Count the length of current block of the same character
            while (j < n && text[j] == ch) j++;
            var len1 = j - i;

            // Try extending this block by 1 (if more of ch exists elsewhere)
            int total = freq[ch - 'a'];
            if (len1 < total)
            {
                maxLen = Math.Max(maxLen, len1 + 1);
            }
            else
            {
                maxLen = Math.Max(maxLen, len1);
            }

            // Check for pattern like: block1 ch block2 (e.g., aaa_b_aaa)
            var k = j + 1;
            if (k < n && text[k] == ch)
            {
                int l = k;
                while (l < n && text[l] == ch) l++;
                int len2 = l - k;
                int combined = len1 + len2;

                if (combined < total)
                {
                    maxLen = Math.Max(maxLen, combined + 1);
                }
                else
                {
                    maxLen = Math.Max(maxLen, combined);
                }

            }

            i = j;
        }

        return maxLen;
    }
}
