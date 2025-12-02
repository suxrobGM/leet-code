using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1927
{
    /// <summary>
    /// 1927. Sum Game - Medium
    /// <a href="https://leetcode.com/problems/sum-game">See the problem</a>
    /// </summary>
    public bool SumGame(string num)
    {
        int n = num.Length;
        int half = n / 2;

        int sumL = 0, sumR = 0;
        int cntL = 0, cntR = 0;

        // Left half
        for (int i = 0; i < half; i++)
        {
            if (num[i] == '?')
                cntL++;
            else
                sumL += num[i] - '0';
        }

        // Right half
        for (int i = half; i < n; i++)
        {
            if (num[i] == '?')
                cntR++;
            else
                sumR += num[i] - '0';
        }

        int totalQ = cntL + cntR;

        // If total number of '?' is odd, Alice always wins
        if ((totalQ & 1) == 1)
            return true;

        int diff = sumL - sumR;
        int deltaCnt = cntR - cntL; // always even when totalQ is even

        // If diff matches exactly what Bob needs to balance using the remaining '?',
        // then Bob can force equality; otherwise Alice can force inequality.
        if (diff == 9 * (deltaCnt / 2))
            return false; // Bob wins
        else
            return true;  // Alice wins
    }
}
