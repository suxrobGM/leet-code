using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution767
{
    /// <summary>
    /// 767. Reorganize String - Medium
    /// <a href="https://leetcode.com/problems/reorganize-string">See the problem</a>
    /// </summary>
    public string ReorganizeString(string s)
    {
        var n = s.Length;
        var counts = new int[26];
        foreach (var c in s)
        {
            counts[c - 'a']++;
        }

        var maxCount = 0;
        var maxChar = 0;
        for (var i = 0; i < 26; i++)
        {
            if (counts[i] > maxCount)
            {
                maxCount = counts[i];
                maxChar = i;
            }
        }

        if (maxCount > (n + 1) / 2)
        {
            return string.Empty;
        }

        var result = new char[n];
        var index = 0;
        while (counts[maxChar] > 0)
        {
            result[index] = (char)(maxChar + 'a');
            index += 2;
            counts[maxChar]--;
        }

        for (var i = 0; i < 26; i++)
        {
            while (counts[i] > 0)
            {
                if (index >= n)
                {
                    index = 1;
                }

                result[index] = (char)(i + 'a');
                index += 2;
                counts[i]--;
            }
        }

        return new string(result);
    }
}
