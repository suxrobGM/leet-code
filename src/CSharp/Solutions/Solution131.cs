using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution131
{
    /// <summary>
    /// 131. Palindrome Partitioning - Medium
    /// <a href="https://leetcode.com/problems/palindrome-partitioning">See the problem</a>
    /// </summary>
    public IList<IList<string>> Partition(string s)
    {
        var result = new List<IList<string>>();
        DFS(s, 0, new List<string>(), result);
        return result;
    }
    
    private void DFS(string s, int start, List<string> current, List<IList<string>> result)
    {
        if (start == s.Length)
        {
            result.Add(new List<string>(current));
            return;
        }
        
        for (var end = start + 1; end <= s.Length; end++)
        {
            var substring = s[start..end];
            
            if (IsPalindrome(substring))
            {
                current.Add(substring);
                DFS(s, end, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
    
    private bool IsPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;
        
        while (left < right)
        {
            if (s[left++] != s[right--])
            {
                return false;
            }
        }
        
        return true;
    }
}
