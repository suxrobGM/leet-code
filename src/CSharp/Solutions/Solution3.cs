﻿namespace LeetCode.Solutions;

public class Solution3
{
    /// <summary>
    /// Given a string s, find the length of the longest substring without repeating characters.
    /// <a href="https://leetcode.com/problems/longest-substring-without-repeating-characters/">See the problem</a>
    /// </summary>
    public int LengthOfLongestSubstring(string s)
    {
        var len = s.Length;

        if (len <= 1)
            return len;

        int r = 0, l = 0;
        var substr = new HashSet<char>();
        var maxSubstr = 0;
        while (r < len)
        {
            if (!substr.Contains(s[r]))
            {
                substr.Add(s[r]);
                r++;
                maxSubstr = Math.Max(maxSubstr, substr.Count);
            }
            else
            {
                substr.Remove(s[l]);
                l++;
            }
        }
        return maxSubstr;
    }
}