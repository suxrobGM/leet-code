using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1573
{
    /// <summary>
    /// 1573. Number of Ways to Split a String - Medium
    /// <a href="https://leetcode.com/problems/number-of-ways-to-split-a-string">See the problem</a>
    /// </summary>
    public int NumWays(string s)
    {
        int MOD = 1_000_000_007;
        int totalOnes = 0;
        foreach (char c in s)
        {
            if (c == '1') totalOnes++;
        }

        if (totalOnes % 3 != 0) return 0;

        int n = s.Length;

        // Case when total number of 1s is 0
        if (totalOnes == 0)
        {
            long ways = (long)(n - 1) * (n - 2) / 2;
            return (int)(ways % MOD);
        }

        int onesPerPart = totalOnes / 3;
        int firstSplitWays = 0, secondSplitWays = 0;
        int onesCount = 0;

        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1') onesCount++;
            if (onesCount == onesPerPart) firstSplitWays++;
            else if (onesCount == 2 * onesPerPart) secondSplitWays++;
        }

        return (int)((long)firstSplitWays * secondSplitWays % MOD);
    }
}
