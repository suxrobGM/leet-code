using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1864
{
    /// <summary>
    /// 1864. Minimum Number of Swaps to Make the Binary String Alternating - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-swaps-to-make-the-binary-string-alternating">See the problem</a>
    /// </summary>
    public int MinSwaps(string s)
    {
        int n = s.Length;
        int count0 = 0, count1 = 0;

        foreach (char c in s)
        {
            if (c == '0') count0++;
            else count1++;
        }

        if (Math.Abs(count0 - count1) > 1) return -1;

        int swapsPattern1 = 0; // Starting with '0'
        int swapsPattern2 = 0; // Starting with '1'

        for (int i = 0; i < n; i++)
        {
            char expectedCharPattern1 = (i % 2 == 0) ? '0' : '1';
            char expectedCharPattern2 = (i % 2 == 0) ? '1' : '0';

            if (s[i] != expectedCharPattern1) swapsPattern1++;
            if (s[i] != expectedCharPattern2) swapsPattern2++;
        }

        if (count0 > count1) return swapsPattern1 / 2;
        if (count1 > count0) return swapsPattern2 / 2;

        return Math.Min(swapsPattern1, swapsPattern2) / 2;
    }
}
