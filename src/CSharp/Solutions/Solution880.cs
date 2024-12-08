using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution880
{
    /// <summary>
    /// 880. Decoded String at Index - Medium
    /// <a href="https://leetcode.com/problems/decoded-string-at-index">See the problem</a>
    /// </summary>
    public string DecodeAtIndex(string s, int k)
    {
        long decodedLength = 0;

        // Step 1: Calculate the total decoded length
        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                decodedLength *= c - '0';
            }
            else
            {
                decodedLength++;
            }
        }

        // Step 2: Traverse backwards to find the k-th character
        for (int i = s.Length - 1; i >= 0; i--)
        {
            char c = s[i];
            if (char.IsDigit(c))
            {
                decodedLength /= c - '0';
                k %= (int)decodedLength;
            }
            else
            {
                if (k == 0 || k == decodedLength)
                {
                    return c.ToString();
                }
                decodedLength--;
            }
        }

        return "";
    }
}
