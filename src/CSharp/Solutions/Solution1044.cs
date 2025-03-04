using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1044
{
    private const long MOD = (1L << 61) - 1;
    private const long BASE = 31; // Base for hashing

    /// <summary>
    /// 1044. Longest Duplicate Substring - Hard
    /// <a href="https://leetcode.com/problems/longest-duplicate-substring</a>
    /// </summary>
    public string LongestDupSubstring(string s)
    {
        int left = 1, right = s.Length - 1;
        var result = "";

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            var duplicate = FindDuplicateSubstring(s, mid);
            
            if (duplicate != "")
            {
                result = duplicate;
                left = mid + 1; // Try finding a longer one
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    private string FindDuplicateSubstring(string s, int length)
    {
        Dictionary<long, List<int>> hashMap = [];
        long hash = 0, basePow = 1;

        // Compute the hash of the first 'length' characters
        for (int i = 0; i < length; i++)
        {
            hash = (hash * BASE + s[i]) % MOD;
            basePow = basePow * BASE % MOD;
        }

        hashMap[hash] = [0];

        // Sliding window: Compute rolling hashes
        for (int i = length; i < s.Length; i++)
        {
            hash = ((hash * BASE + s[i] - s[i - length] * basePow) % MOD + MOD) % MOD;

            if (hashMap.ContainsKey(hash))
            {
                foreach (var start in hashMap[hash])
                {
                    if (s.Substring(start, length) == s.Substring(i - length + 1, length))
                    {
                        return s.Substring(start, length);
                    }
                }
            }

            if (!hashMap.ContainsKey(hash))
                hashMap[hash] = [];
            hashMap[hash].Add(i - length + 1);
        }

        return "";
    }
}
