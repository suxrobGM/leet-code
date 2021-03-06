namespace LeetCode.Solutions;

public partial class Solution
{
    /// <summary>
    /// Implement strStr().
    /// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
    /// Clarification:
    /// What should we return when needle is an empty string? This is a great question to ask during an interview.
    /// For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
    /// <see href="https://leetcode.com/problems/implement-strstr/">See the problem</see>
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
}
