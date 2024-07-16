namespace LeetCode.Solutions;

public class Solution392
{
    /// <summary>
    /// 392. Is Subsequence - Easy
    /// <a href="https://leetcode.com/problems/is-subsequence">See the problem</a>
    /// </summary>
    public bool IsSubsequence(string s, string t) 
    {
        var i = 0;
        var j = 0;
        
        while (i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
            {
                i++;
            }
            
            j++;
        }
        
        return i == s.Length;
    }
}
