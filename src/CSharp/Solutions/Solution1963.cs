using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1963
{
    /// <summary>
    /// 1963. Minimum Number of Swaps to Make the String Balanced - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-swaps-to-make-the-string-balanced">See the problem</a>
    /// </summary>
    public int MinSwaps(string s)
    {
        int imbalance = 0;
        int maxImbalance = 0;

        foreach (char c in s)
        {
            if (c == '[')
            {
                imbalance--;
            }
            else // c == ']'
            {
                imbalance++;
            }

            maxImbalance = Math.Max(maxImbalance, imbalance);
        }

        return (maxImbalance + 1) / 2;
    }
}
