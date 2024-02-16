namespace LeetCode.Solutions;

public class Solution28
{
    /// <summary>
    /// Implement strStr().
    /// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
    /// Clarification:
    /// What should we return when needle is an empty string? This is a great question to ask during an interview.
    /// For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
    /// <a href="https://leetcode.com/problems/implement-strstr/">See the problem</a>
    /// </summary>
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle) || string.IsNullOrEmpty(haystack))
        {
            return 0;
        }

        if (needle.Length > haystack.Length)
        {
            return -1;
        }

        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle[0])
            {
                bool flag = true;

                for (int j = 0; j < needle.Length; j++)
                {
                    if ((i + j) >= haystack.Length || 
                        needle[j] != haystack[i + j])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    return i;
            }
        }

        return -1;
    }
    
    public int StrStr2(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle))
        {
            return 0;
        }
        
        for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            if (haystack.Substring(i, needle.Length) == needle)
            {
                return i;
            }
        }
        
        return -1;
    }
    
    public int StrStr3(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle))
        {
            return 0;
        }

        if (needle.Length > haystack.Length)
        {
            return -1;
        }

        return haystack.IndexOf(needle, StringComparison.Ordinal); 
    }
}
