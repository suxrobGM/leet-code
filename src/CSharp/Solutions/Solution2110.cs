using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2110
{
    /// <summary>
    /// 2110. Number of Smooth Descent Periods of a Stock - Medium
    /// <a href="https://leetcode.com/problems/number-of-smooth-descent-periods-of-a-stock">See the problem</a>
    /// </summary>
    public long GetDescentPeriods(int[] prices)
    {
        var count = 0L;
        var length = 1;

        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i - 1] - prices[i] == 1)
            {
                length++;
            }
            else
            {
                count += GetCount(length);
                length = 1;
            }
        }

        count += GetCount(length);

        return count;
    }

    private static long GetCount(int length)
    {
        return (long)length * (length + 1) / 2;
    }
}
