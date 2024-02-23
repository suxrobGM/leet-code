namespace LeetCode.Solutions;

public class Solution205
{
    /// <summary>
    /// 205. Isomorphic Strings
    /// <a href="https://leetcode.com/problems/isomorphic-strings">See the problem</a>
    /// </summary>
    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        
        var sMap = new Dictionary<char, char>();
        var tMap = new Dictionary<char, char>();

        for (var i = 0; i < s.Length; i++)
        {
            if (sMap.TryGetValue(s[i], out var sValue) && sValue != t[i] ||
                tMap.TryGetValue(t[i], out var tValue) && tValue != s[i])
            {
                return false;
            }

            sMap[s[i]] = t[i];
            tMap[t[i]] = s[i];
        }

        return true;
    }
}
