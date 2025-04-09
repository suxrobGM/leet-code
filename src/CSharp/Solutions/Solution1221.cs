using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1221
{
    /// <summary>
    /// 1221. Split a String in Balanced Strings - Easy
    /// <a href="https://leetcode.com/problems/split-a-string-in-balanced-strings">See the problem</a>
    /// </summary>
    public int BalancedStringSplit(string s)
    {
        int balanceCount = 0;
        int result = 0;

        foreach (char c in s)
        {
            if (c == 'L')
                balanceCount++;
            else if (c == 'R')
                balanceCount--;

            if (balanceCount == 0)
                result++;
        }

        return result;
    }
}
