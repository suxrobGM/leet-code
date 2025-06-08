using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1513
{
    /// <summary>
    /// 1513. Number of Substrings With Only 1s - Medium
    /// <a href="https://leetcode.com/problems/number-of-substrings-with-only-1s">See the problem</a>
    /// </summary>
    public int NumSub(string s)
    {
        const int MOD = 1_000_000_007;
        long res = 0;
        int count = 0;

        foreach (char c in s)
        {
            if (c == '1')
            {
                count++;
            }
            else
            {
                res += (long)count * (count + 1) / 2;
                res %= MOD;
                count = 0;
            }
        }

        // Add last segment if string ends with '1'
        if (count > 0)
        {
            res += (long)count * (count + 1) / 2;
            res %= MOD;
        }

        return (int)res;
    }
}
