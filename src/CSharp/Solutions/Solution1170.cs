using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1170
{
    /// <summary>
    /// 1170. Compare Strings by Frequency of the Smallest Character - Medium
    /// <a href="https://leetcode.com/problems/invalid-transactions">See the problem</a>
    /// </summary>
    public int[] NumSmallerByFrequency(string[] queries, string[] words)
    {
        int[] fQueries = new int[queries.Length];
        int[] fWords = new int[words.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            fQueries[i] = GetFrequency(queries[i]);
        }

        for (int i = 0; i < words.Length; i++)
        {
            fWords[i] = GetFrequency(words[i]);
        }

        Array.Sort(fWords);

        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            result[i] = CountGreater(fWords, fQueries[i]);
        }

        return result;
    }

    private int GetFrequency(string s)
    {
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (count[i] > 0)
            {
                return count[i];
            }
        }

        return 0;
    }

    private int CountGreater(int[] fWords, int fQuery)
    {
        int left = 0, right = fWords.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (fWords[mid] > fQuery)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return fWords.Length - left;
    }
}
