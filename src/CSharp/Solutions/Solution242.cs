namespace LeetCode.Solutions;

public class Solution242
{
    /// <summary>
    /// 242. Valid Anagram
    /// <a href="https://leetcode.com/problems/valid-anagram">See the problem</a>
    /// </summary>
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        
        var sMap = new Dictionary<char, int>();
        
        foreach (var letter in s)
        {
            if (!sMap.TryAdd(letter, 1))
            {
                sMap[letter]++;
            }
        }
        
        foreach (var letter in t)
        {
            if (!sMap.ContainsKey(letter))
            {
                return false;
            }
            
            sMap[letter]--;
            
            if (sMap[letter] == 0)
            {
                sMap.Remove(letter);
            }
        }
        
        return sMap.Count == 0;
    }
}
