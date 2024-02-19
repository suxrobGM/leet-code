namespace LeetCode.Solutions;

public class Solution3
{
    /// <summary>
    /// Given a string s, find the length of the longest substring without repeating characters.
    /// <a href="https://leetcode.com/problems/longest-substring-without-repeating-characters/">See the problem</a>
    /// </summary>
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length <= 1)
        {
            return s.Length;
        }

        var right = 0;
        var left = 0;
        var substr = new HashSet<char>();
        var maxSubstr = 0;
        
        while (right < s.Length)
        {
            if (substr.Add(s[right]))
            {
                right++;
                maxSubstr = Math.Max(maxSubstr, substr.Count);
            }
            else
            {
                substr.Remove(s[left]);
                left++;
            }
        }
        return maxSubstr;
    }
}
