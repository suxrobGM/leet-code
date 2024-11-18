using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution828
{
    /// <summary>
    /// 828. Count Unique Characters of All Substrings of a Given String - Hard
    /// <a href="https://leetcode.com/problems/count-unique-characters-of-all-substrings-of-a-given-string">See the problem</a>
    /// </summary>
    public int UniqueLetterString(string s)
    {
        var n = s.Length;

        // Arrays to store previous and next occurrences
        var prev = new int[n];
        var next = new int[n];
        var lastSeen = new Dictionary<char, int>();

        // Compute previous occurrences
        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            prev[i] = lastSeen.ContainsKey(c) ? lastSeen[c] : -1;
            lastSeen[c] = i;
        }

        // Reset dictionary for next occurrences
        lastSeen.Clear();

        // Compute next occurrences
        for (int i = n - 1; i >= 0; i--)
        {
            char c = s[i];
            next[i] = lastSeen.ContainsKey(c) ? lastSeen[c] : n;
            lastSeen[c] = i;
        }

        // Calculate contributions
        int result = 0;
        int mod = 1_000_000_007;
        for (int i = 0; i < n; i++)
        {
            result = (result + (i - prev[i]) * (next[i] - i)) % mod;
        }

        return result;
    }
}
