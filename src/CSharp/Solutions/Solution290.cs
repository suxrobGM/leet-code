namespace LeetCode.Solutions;

public class Solution290
{
    /// <summary>
    /// 290. Word Pattern
    /// <a href="https://leetcode.com/problems/word-pattern">See the problem</a>
    /// </summary>
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split(' ');
        var patternMap = new Dictionary<char, string>();
        
        if (pattern.Length != words.Length)
        {
            return false;
        }

        for (var i = 0; i < words.Length; i++)
        {
            if (patternMap.TryGetValue(pattern[i], out var value) && value != words[i])
            {
                return false;
            }
            
            if (patternMap.ContainsValue(words[i]) && !patternMap.ContainsKey(pattern[i]))
            {
                return false;
            }

            patternMap[pattern[i]] = words[i];
        }

        return true;
    }
}
