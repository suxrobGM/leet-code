using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1736
{
    const int MOD = 1_000_000_007;

    /// <summary>
    /// 1736. Latest Time by Replacing Hidden Digits - Easy
    /// <a href="https://leetcode.com/problems/latest-time-by-replacing-hidden-digits">See the problem</a>
    /// </summary>
    public string MaximumTime(string time)
    {
        char[] t = time.ToCharArray();

        // Hour tens
        if (t[0] == '?')
        {
            if (t[1] == '?' || t[1] <= '3')
                t[0] = '2';
            else
                t[0] = '1';
        }

        // Hour ones
        if (t[1] == '?')
        {
            if (t[0] == '2') t[1] = '3';
            else t[1] = '9';
        }

        // Minute tens
        if (t[3] == '?') t[3] = '5';

        // Minute ones
        if (t[4] == '?') t[4] = '9';

        return new string(t);
    }
}

