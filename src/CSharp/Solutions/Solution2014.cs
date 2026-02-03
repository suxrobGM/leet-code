namespace LeetCode.Solutions;

public class Solution2014
{
    /// <summary>
    /// 2014. Longest Subsequence Repeated k Times - Hard
    /// <a href="https://leetcode.com/problems/longest-subsequence-repeated-k-times">See the problem</a>
    /// </summary>
    public string LongestSubsequenceRepeatedK(string s, int k)
    {
        // Count character frequencies
        int[] freq = new int[26];
        foreach (char c in s)
            freq[c - 'a']++;

        // Get characters appearing >= k times (z to a for lex largest)
        string validChars = "";
        for (int i = 25; i >= 0; i--)
        {
            if (freq[i] >= k)
                validChars += (char)('a' + i);
        }

        string result = "";
        Queue<string> queue = new();
        queue.Enqueue("");

        // BFS to explore all valid subsequences
        while (queue.Count > 0)
        {
            string curr = queue.Dequeue();

            foreach (char c in validChars)
            {
                string next = curr + c;
                if (IsKSubsequence(s, next, k))
                {
                    if (next.Length > result.Length ||
                        (next.Length == result.Length && string.Compare(next, result) > 0))
                    {
                        result = next;
                    }
                    queue.Enqueue(next);
                }
            }
        }

        return result;
    }

    private static bool IsKSubsequence(string s, string seq, int k)
    {
        int i = 0;
        for (int rep = 0; rep < k; rep++)
        {
            foreach (char c in seq)
            {
                while (i < s.Length && s[i] != c)
                    i++;
                if (i >= s.Length)
                    return false;
                i++;
            }
        }
        return true;
    }
}
